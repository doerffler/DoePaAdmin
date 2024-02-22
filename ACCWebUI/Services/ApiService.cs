﻿using ACCDataModel.Stammdaten;
using ACCWebUI.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ACCWebUI.Services
{
    [Authorize]
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenAcquisition _tokenAcquisition;
        private string _apiBaseUrl;
        private ResourceEndpoint _endpoint;

        public ApiService(HttpClient httpClient, ITokenAcquisition tokenAcquisition)
        {
            _httpClient = httpClient;
            _tokenAcquisition = tokenAcquisition;
        }

        public void InitializeEndpoint(string apiBaseUrl, ResourceEndpoint endpoint) 
        {
            _endpoint = endpoint;
            _apiBaseUrl = apiBaseUrl;
        }

        private async Task<string> AcquireToken()
        {
            string[] scopes = { "api://02513cef-ceba-453b-89c2-7cb1783c416a/User.Read" };
            var authResult = await _tokenAcquisition.GetAuthenticationResultForUserAsync(scopes);
            return authResult.AccessToken;
        }

        private async Task<T> SendRequestAsync<T>(string relativeUrl)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await AcquireToken());
            HttpResponseMessage response = await _httpClient.GetAsync(_apiBaseUrl + relativeUrl);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseBody);
            }
            else
            {
                return default;
            }
        }

        public async Task<T> GetAsync<T>(int currentPage, int pageSize)
        {
            return await SendRequestAsync<T>($"{_endpoint}?currentPage={currentPage}&pageSize={pageSize}");
        }

        public async Task<T> GetByIdAsync<T>(int itemId)
        {
            return await SendRequestAsync<T>($"{_endpoint}/{itemId}");
        }

        public Task<T> CreateAsync<T>(T item)
        {
            return null;
        }

        public Task<T> UpdateAsync<T>(int itemId, T item)
        {
            return null;
        }

        public Task<T> DeleteAsync<T>(int itemId)
        {
            return null;
        }
    }
}
