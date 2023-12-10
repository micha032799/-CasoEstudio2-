using CasoEstudio2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CasoEstudio2.Controllers
{
    public class CasasController : Controller
    {
        CasasModel casasModel = new CasasModel();
        public ActionResult ConsultaCasas()
        {
            var datos = casasModel.ConsultaCasas();
            return View(datos);
        }



        public ActionResult AlquilerCasas()
        {
            ViewBag.Alquiler = casasModel.AlquilerCasas().;
            var datos = casasModel.ConsultaCasas();
            //var datos = casasModel.ConsultaCasa(IdCasa);
            return View(datos[1]);
        }
    }
}