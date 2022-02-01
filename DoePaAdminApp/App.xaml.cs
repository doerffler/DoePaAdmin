﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using DoePaAdmin.ViewModel.Model;
using DoePaAdmin.ViewModel.Services;
using DoePaAdmin.ViewModel;
using DoePaAdminApp.Views;

namespace DoePaAdminApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly IHost host;

        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {

            host = Host.CreateDefaultBuilder()  // Use default settings
                                                //new HostBuilder()          // Initialize an empty HostBuilder
                    .ConfigureAppConfiguration((context, builder) =>
                    {
                        // Add other configuration files...
                        builder.AddJsonFile("appsettings.Development.json", optional: true);
                    }).ConfigureServices((context, services) =>
                    {
                        ConfigureServices(context.Configuration, services);
                    })
                    .ConfigureLogging(logging =>
                    {
                        // Add other loggers...
                    })
                    .Build();

            ServiceProvider = host.Services;

        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {

            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            services.Configure<DPAppConnectionSettings>(configuration.GetSection(nameof(DPAppConnectionSettings)));

            services.AddScoped<ISampleService, SampleService>();
            services.AddScoped<IDPAppService, DPAppService>();

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<ImportKostenstellen>();

            services.AddTransient<MainWindow>();
            services.AddTransient<ImportKostenstellen>();

        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();

            var window = ServiceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }
    }
}
