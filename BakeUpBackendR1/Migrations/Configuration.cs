namespace BakeUpBackendR1.Migrations
{
    using BakeUpBackendR1.Entities;
    using BakeUpBackendR1.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Transactions;

    internal sealed class Configuration : DbMigrationsConfiguration<BakeUpBackendR1.Models.ApplicationDbContext>
    {
        private bool seedEnabled = true;
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BakeUpBackendR1.Models.ApplicationDbContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BakeUpBackendR1.Models.ApplicationDbContext context)
        {
            //string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            //UriBuilder uri = new UriBuilder(codeBase);
            //string path = Uri.UnescapeDataString(uri.Path);
            //var baseDir = Path.GetDirectoryName(path) + "\\Migrations\\CreateViews.sql";

            //context.Database.ExecuteSqlCommand(File.ReadAllText(baseDir));

            if (seedEnabled == false)
                return;

            var sysPars = new List<SysPar>() {
                new SysPar() { Type="test", Name="test",Val="test" }
            };
            var ingredienti = new List<Ingrediente>() {
                new Ingrediente(){ NomeIngrediente="IngredienteTest1", CalcioMg=1}
            };
            var ricette = new List<Ricetta>() {
                new Ricetta(){
                    NomeProdotto ="ProdottoTest1",
                    DescrizioneProdotto ="Lorem ipsum"
                }
            };

            using (var trnscope = new TransactionScope())
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    foreach (var sysPar in sysPars)
                    {
                        db.SysPars.AddOrUpdate(sysPar);
                    }
                    foreach (var ing in ingredienti)
                    {
                        db.Ingredienti.AddOrUpdate(ing);
                    }
                    foreach (var ric in ricette)
                    {
                        db.Ricette.AddOrUpdate(ric);
                    }

                    db.SaveChanges();
                
                }
                trnscope.Complete();
            }
        }

    }
}
