using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeUpBackendR1.Entities
{
    public class Ingrediente:ValidEntity
    {
        public string Codice { get; set; }
        public string NomeIngrediente { get; set; }
        public  float Kcal { get; set; }
        public float KJoule { get; set; }
        public float SodioMg { get; set; }
        public float ZuccheriGr { get; set; }
        public float GrSaturi { get; set; }
        public float ProteineGr { get; set; }
        public float GrassiGr { get; set; }
        public float FibraGr { get; set; }
        public float MagnesioMg { get; set; }
        public float PotassioMg { get; set; }
        public float FerroMg { get; set; }
        public float CalcioMg { get; set; }
        public float FosforoMg { get; set; }
        public float Colesterolo { get; set; }
        public float VitaminaA { get; set; }
        public float VitaminaC { get; set; }
    }
}