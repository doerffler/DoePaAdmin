﻿using ACC.ViewModel.Messages;
using ACC.ViewModel.Services;
using ACCDataModel.Kostenrechnung;
using ACCDataModel.Stammdaten;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ACC.ViewModel
{
    public class ManageEingangsrechnungenViewModel : ACCViewModelBase
    {

        private Geschaeftsjahr _selectedGeschaeftsjahr;

        public Geschaeftsjahr SelectedGeschaeftsjahr
        {
            get => _selectedGeschaeftsjahr;
            set => SetProperty(ref _selectedGeschaeftsjahr, value, true);
        }

        private Eingangsrechnung _selectedRechnung;

        public Eingangsrechnung SelectedRechnung
        {
            get => _selectedRechnung;
            set => SetProperty(ref _selectedRechnung, value, true);
        }

        private ObservableCollection<Eingangsrechnung> _rechnungen;

        public ObservableCollection<Eingangsrechnung> Rechnungen
        {
            get => _rechnungen;
            set => SetProperty(ref _rechnungen, value, true);
        }

        public static Uri InvoiceDocumentUrl
        {
            //TODO: This is supposed to return something like SelectedRechnung.ZugehoerigesDokument.DokumentUrl
            get => new ("file:///D:/Cloud/b.telligent%20group/Doerffler%20Buchhaltung%20-%20Dokumente/Rechnungen_Ausgang/2021-2022/20210154_FREELANCER_Nachtrag_764.PDF");
        }

        public IRelayCommand AddRechnungCommand { get; }

        public IRelayCommand RemoveRechnungCommand { get; }


        public ManageEingangsrechnungenViewModel(IACCService accService, IUserInteractionService userInteractionService) : base(accService, userInteractionService)
        {

            //TODO: Implement CanExecute-Functionality
            AddRechnungCommand = new AsyncRelayCommand(DoAddRechnungAsync);
            RemoveRechnungCommand = new RelayCommand(DoRemoveRechnung);

            GetData();

            Messenger.Register<ManageEingangsrechnungenViewModel, RefreshMessage, string>(this, "Refresh", (r, m) => r.OnRefreshReceive(m));
        }

        private void GetData()
        {
            Rechnungen = new(Task.Run(async () => await ACCService.GetEingangsrechnungenAsync()).Result);
            SelectedGeschaeftsjahr = Task.Run(async () => await CalculateCurrentGeschaeftsjahrAsync()).Result;

            Messenger.Send(new StatusbarMessage("ManageEingangsrechnungenViewModel loaded"), "Statusbar");
        }

        private void OnRefreshReceive(RefreshMessage message)
        {
            GetData();
        }

        private void DoRemoveRechnung()
        {

            if (SelectedRechnung != null)
            {
                ACCService.RemoveEingangsrechnung(SelectedRechnung);
                _ = Rechnungen.Remove(SelectedRechnung);
            }

        }

        private async Task DoAddRechnungAsync(CancellationToken cancellationToken = default)
        {

            string rechnungsNummer = GetNextRechnungsnummer();

            if (rechnungsNummer != null)
            {
                Eingangsrechnung newRechnung = await ACCService.CreateEingangsrechnungAsync(cancellationToken);
                newRechnung.RechnungsNummer = rechnungsNummer;
                Rechnungen.Add(newRechnung);
            }
        }

        private string GetNextRechnungsnummer()
        {
            string nextNumber = string.Empty;
            //TODO: Finish function.

            return SelectedGeschaeftsjahr?.Rechnungsprefix ?? string.Empty + nextNumber;
        }

        private async Task<Geschaeftsjahr> CalculateCurrentGeschaeftsjahrAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<Geschaeftsjahr> listGeschaeftsjahre = await ACCService.GetGeschaeftsjahreAsync(cancellationToken);

            Geschaeftsjahr geschaeftsjahrToReturn = listGeschaeftsjahre.FirstOrDefault(gj => gj.DatumVon <= DateTime.Now && gj.DatumBis >= DateTime.Now);

            return geschaeftsjahrToReturn;
        }
    }
}
