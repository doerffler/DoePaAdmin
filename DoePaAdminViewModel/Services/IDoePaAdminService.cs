﻿using DoePaAdminDataModel.API;
using DoePaAdminDataModel.Kostenrechnung;
using DoePaAdminDataModel.Stammdaten;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoePaAdmin.ViewModel.Services
{
    public interface IDoePaAdminService
    {

        #region Kostenstelle

        public Task<IEnumerable<Kostenstelle>> GetKostenstellenAsync(CancellationToken cancellationToken = default);
        public Task<Kostenstelle> CreateKostenstelleAsync(CancellationToken cancellationToken = default);
        public void RemoveKostenstelle(Kostenstelle kostenstelleToRemove);

        #endregion 

        #region Mitarbeiter

        public Task<IEnumerable<Mitarbeiter>> GetMitarbeiterAsync(CancellationToken cancellationToken = default);

        public Task<Mitarbeiter> CreateMitarbeiterAsync(CancellationToken cancellationToken = default);

        public void RemoveMitarbeiter(Mitarbeiter mitarbeiterToRemove);

        public Task<Anstellungsdetail> CreateAnstellungsdetailAsync(CancellationToken cancellationToken = default);

        public Task<IEnumerable<EmployeeInvoicedHours>> GetEmployeeInvoicedHours(int UserId, CancellationToken cancellationToken = default);

        #endregion

        #region Kunde

        public Task<IEnumerable<Kunde>> GetKundenAsync(CancellationToken cancellationToken = default);
        public Task<Kunde> CreateKundeAsync(CancellationToken cancellationToken = default);
        public void RemoveKunde(Kunde selectedKunde);

        #endregion

        #region Projekt

        public Task<IEnumerable<Projekt>> GetProjekteAsync(CancellationToken cancellationToken = default);

        public Task<Projekt> CreateProjektAsync(CancellationToken cancellationToken = default);

        public Task<Skill> CreateSkillAsync(CancellationToken cancellationToken = default);

        public Task<IEnumerable<Skill>> GetSkillsAsync(CancellationToken cancellationToken = default);
       
        void RemoveSkill(Skill selectedSkill);

        #endregion

        #region Auftrag

        public Task<IEnumerable<Auftrag>> GetAuftraegeAsync(CancellationToken cancellationToken = default);

        public Task<Auftrag> CreateAuftragAsync(CancellationToken cancellationToken = default);

        public Task<IEnumerable<Auftragsposition>> GetAuftragspositionAsync(CancellationToken cancellationToken = default);
        
        public Task<Auftragsposition> CreateAuftragspositionAsync(CancellationToken cancellationToken = default);

        #endregion

        #region Ausgangsrechnungen

        public Task<IEnumerable<Ausgangsrechnung>> GetAusgangsrechnungenAsync(CancellationToken cancellationToken = default);

        public Task<Ausgangsrechnung> CreateAusgangsrechnungAsync(CancellationToken cancellationToken = default);

        public void RemoveAusgangsrechnung(Ausgangsrechnung ausgangsrechnungToRemove);
        
        #endregion

        #region Masterdata

        public Task<IEnumerable<Waehrung>> GetWaehrungenAsync(CancellationToken cancellationToken = default);
        public Task<Waehrung> CreateWaehrungAsync(CancellationToken cancellationToken = default);
        void RemoveWaehrung(Waehrung selectedWaehrung);

        public Task<IEnumerable<Abrechnungseinheit>> GetAbrechnungseinheitenAsync(CancellationToken cancellationToken = default);
        public Task<Abrechnungseinheit> CreateAbrechnungseinheitAsync(CancellationToken cancellationToken = default);
        void RemoveAbrechnungseinheit(Abrechnungseinheit selectedAbrechnungseinheit);

        public Task<IEnumerable<T>> GetGeschaeftspartnerAsync<T>(CancellationToken cancellationToken = default) where T : Geschaeftspartner;
        public Task<T> CreateGeschaeftspartnerAsync<T>(CancellationToken cancellationToken = default) where T : Geschaeftspartner, new();
        public void RemoveGeschaeftspartner<T>(T debitorToRemove) where T : Geschaeftspartner;

        public Task<IEnumerable<Geschaeftsjahr>> GetGeschaeftsjahreAsync(CancellationToken cancellationToken = default);
        public Task<Geschaeftsjahr> CreateGeschaeftsjahrAsync(CancellationToken cancellationToken = default);        
        public void RemoveGeschaeftsjahr(Geschaeftsjahr selectedGeschaeftsjahr);

        public Task<IEnumerable<Feiertag>> GetFeiertageAsync(CancellationToken cancellationToken = default);
        public Task<Feiertag> CreateFeiertagAsync(CancellationToken cancellationToken = default);
        public void RemoveFeiertag(Feiertag selectedFeiertag);

        public Task<IEnumerable<Postleitzahl>> GetPostleitzahlenAsync(CancellationToken cancellationToken = default);
        public Task<Postleitzahl> CreatePostleitzahlAsync(CancellationToken cancellationToken = default);
        public void RemovePostleitzahl(Postleitzahl selectedPostleitzahl);

        public Task<IEnumerable<Adresse>> GetAdressenAsync(CancellationToken cancellationToken = default);
        public Task<Adresse> CreateAdresseAsync(CancellationToken cancellationToken = default);
        public void RemoveAdresse(Adresse selectedAdresse);

        public Task<IEnumerable<Kostenstellenart>> GetKostenstellenartenAsync(CancellationToken cancellationToken = default);
        public Task<Kostenstellenart> CreateKostenstellenartAsync(CancellationToken cancellationToken = default);
        public void RemoveKostenstellenart(Kostenstellenart selectedKostenstellenart);

        public Task<IEnumerable<Taetigkeit>> GetTaetigkeitenAsync(CancellationToken cancellationToken = default);
        public Task<Taetigkeit> CreateTaetigkeitAsync(CancellationToken cancellationToken = default);
        public void RemoveTaetigkeit(Taetigkeit selectedTaetigkeit);

        #endregion

        #region Utility functions

        public Task<bool> CheckForChangesAsync(CancellationToken cancellationToken = default);

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        #endregion

        
    }
}
