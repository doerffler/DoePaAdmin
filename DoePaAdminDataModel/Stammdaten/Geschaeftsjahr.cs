﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoePaAdminDataModel.Stammdaten
{
    public class Geschaeftsjahr
    {

        public int GeschaeftsjahrId { get; set; }

        public string Name { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime DatumBis { get; set; }

        public string Rechnungsprefix { get; set; }

    }
}