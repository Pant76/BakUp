﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeUpBackendR1.Entities
{
    public class IngredienteRicetta:EntityBase
    {
        public string Codice { get; set; }
        public float Quantita { get; set; }
        public string Um { get; set; }
    }
}