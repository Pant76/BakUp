using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BakeUpBackendR1.Controllers
{
    public class RicetteController : Controller
    {
        // GET: Ricette
        public ActionResult Index()
        {
            return View();
        }
    }
}