using BakeUpBackendR1.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BakeUpBackendR1.Utils
{
    public class UploaderManager
    {

        private string basePath;

        public UploaderManager(string basePath1)
        {
            basePath = basePath1;
        }

        public void ReadRicetteFromFile(out IEnumerable<Ricetta> Ricette,out IEnumerable<Ingrediente> Ingredienti)
        {


            //string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            //UriBuilder uri = new UriBuilder(codeBase);
            //string path = Uri.UnescapeDataString(uri.Path);
            //var basePath= Path.GetDirectoryName(path) + "..\\App_Data\\";


            var ricettePath = Path.Combine(basePath, "Ricette.csv");
            var ingredientiRicettePath = Path.Combine(basePath, "IngredientiRicette.csv");
            var ingredientiPath = Path.Combine(basePath, "Ingredienti.csv");

            var ricetteLines =File.ReadAllLines(ricettePath).Select(i=>i.Split(';')).ToList();
            ricetteLines.RemoveAt(0);

            var ricette= ricetteLines.Select(i => new Ricetta() {
                Codice=i[0],
                NomeProdotto=i[1],
                DescrizioneProdotto=i[2],
                Tags=i[3]
            });

            var ingredientiRicetteLines = File.ReadAllLines(ingredientiRicettePath).Select(i => i.Split(';')).ToList();
            ingredientiRicetteLines.RemoveAt(0);

            var ingredientiRicetteAppo = ingredientiRicetteLines.Select(i =>
                new {
                    CodRicetta=i[0],
                    Codice=i[1],
                    Quantita=i[2],
                    Um=i[3]
                }
            );

            foreach (var ricetta in ricette)
            {
                ricetta.IngredientiRicetta = ingredientiRicetteAppo.Where(i => i.CodRicetta == i.Codice)
                    .Select(i=>new IngredienteRicetta(){
                        Codice=i.Codice,
                        Quantita=float.Parse(i.Quantita),
                        Um=i.Um
                    }).ToList() ;
            }


            var ingredientiLines = File.ReadAllLines(ingredientiPath).Select(i => i.Split(';')).ToList();
            ingredientiLines.RemoveAt(0);

            var ingredienti = ingredientiLines.Select(i => new Ingrediente()
            {
                Codice = i[0],
                NomeIngrediente = i[1],
                Kcal = float.Parse(i[2]),
                KJoule = float.Parse(i[3]),
                SodioMg= float.Parse(i[4]),
                ZuccheriGr= float.Parse(i[5]),
                GrSaturi= float.Parse(i[6]),
                GrassiGr= float.Parse(i[7]),
                FibraGr= float.Parse(i[8]),
                MagnesioMg= float.Parse(i[9]),
                PotassioMg= float.Parse(i[10]),
                FerroMg= float.Parse(i[11]),
                CalcioMg= float.Parse(i[12]),
                FosforoMg= float.Parse(i[13]),
                Colesterolo= float.Parse(i[14]),
                VitaminaA= float.Parse(i[15]),
                VitaminaC= float.Parse(i[16])
            });

            Ricette = ricette;
            Ingredienti = ingredienti;
        }

        
    }
}