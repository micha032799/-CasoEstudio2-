using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CasoEstudio2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AlquilerCasas()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ConsultaCasas()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}