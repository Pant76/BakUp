using BakeUpBackendR1.Entities;
using BakeUpBackendR1.Models;
using BakeUpBackendR1.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace BakeUpBackendR1.Controllers
{
    public class RicetteController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private string basePath;
        // GET: Ricette
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InitUpload()
        {
            return View();
        }

        public ActionResult Save(IEnumerable<HttpPostedFileBase> files)
        {
            // The Name of the Upload component is "files"
            if (files != null )
            {
                foreach (var file in files)
                {
                   // Some browsers send file names with full path. This needs to be stripped.
                   var fileName = Path.GetFileName(file.FileName);
                    basePath = Server.MapPath("~/App_Data/Upload");
                    var physicalPath = Path.Combine(basePath, fileName);

                   // The files are not actually saved in this demo
                     file.SaveAs(physicalPath);
                }
            }
            else
            {
                throw new Exception("devi caricare 3 files");
            }
            
            // Return an empty string to signify success
            return Content("");
        }
        public ActionResult Process()
        {

            try
            {
                basePath = Server.MapPath("~/App_Data/Upload");
                ProcessFiles();

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }

        public void ProcessFiles()
        {

            var upManager = new UploaderManager(basePath);

            upManager.ReadRicetteFromFile(out IEnumerable<Ricetta> ricette, out IEnumerable<Ingrediente> ingredienti);

            using (var transcope=new TransactionScope())
            {
                var ricetteToClose=db.Ricette.Where(r => ricette.Select(i => i.Codice).Contains(r.Codice));
                db.Ricette.RemoveRange(ricetteToClose);
                db.Ingredienti.AddRange(ingredienti);
                db.Ricette.AddRange(ricette);

                db.SaveChanges();
                transcope.Complete();
            }

            ViewBag.TotRicette = ricette.Count();
            ViewBag.TotIngredienti = ingredienti.Count();
        }
    }
}