﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoePaAdminDataModel.Stammdaten
{

    public class Auftragsposition
    {
        public Abrechnungseinheit Abrechnungseinheit { get; set; }

        public int AuftragspositionID { get; set; }

        public int AuftragspositionNummer { get; set; }

        public decimal Auftragsvolumen { get; set; }

        public Auftrag Auftrag { get; set; }   
        
        public string Positionsbezeichnung { get; set; }   
        
        public Waehrung Waehrung { get; set; }   
    }
}
