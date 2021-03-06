﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeUpBackendR1.Entities
{
    public class Ricetta:ValidEntity
    {
        public string Codice { get; set; }
        public string NomeProdotto { get; set; }
        public string DescrizioneProdotto { get; set; }

        public string Tags { get; set; }

        public string CodUtente { get; set; }

        public List<IngredienteRicetta> IngredientiRicetta { get; set; }
        public Ricetta()
        {
            IngredientiRicetta = new List<IngredienteRicetta>();
        }
    }
}