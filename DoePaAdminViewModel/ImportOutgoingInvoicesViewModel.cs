﻿using DoePaAdmin.ViewModel.Model;
using DoePaAdmin.ViewModel.Services;
using DoePaAdminDataModel.DPApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoePaAdmin.ViewModel
{
    public class ImportOutgoingInvoicesViewModel : DoePaAdminViewModelBase
    {

        private IDPAppService _dpAppservice;

        private IDPAppService DPAppService
        {
            get { return _dpAppservice; }
            set { _dpAppservice = value; }
        }

        private OutgoingInvoiceEnumerable _outgoingInvoices = new();

        public OutgoingInvoiceEnumerable OutgoingInvoices
        {
            get => _outgoingInvoices;
            set => SetProperty(ref _outgoingInvoices, value, true);
        }

        public ImportOutgoingInvoicesViewModel(IDoePaAdminService doePaAdminService, IDPAppService dpAppService, IUserInteractionService userInteractionService) : base(doePaAdminService, userInteractionService)
        {
            DPAppService = dpAppService;

            OutgoingInvoices = new OutgoingInvoiceEnumerable(Task.Run(async () => await DPAppService.GetOutgoingInvoicesAsync()).Result);
        }

    }
}
