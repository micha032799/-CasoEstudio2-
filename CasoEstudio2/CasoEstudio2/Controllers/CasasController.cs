using CasoEstudio2.Entities;
using CasoEstudio2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public ActionResult ConsultaCasa(long IdCasa)
        {
            CasasModel casasModel = new CasasModel();
            CasaEnt casa = casasModel.ConsultaCasa(IdCasa);

            if (casa != null)
            {
                return Json(casa.PrecioCasa, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult AlquilerCasas()
        {
            ViewBag.Alquiler = casasModel.AlquilerCasas();
            var datos = casasModel.ConsultaCasas().FirstOrDefault();
            //var datos = casasModel.ConsultaCasa(IdCasa);
            return View(datos);
        }

        [HttpPost]
        public ActionResult ActualizarAlquilerCasa(CasaEnt casa)
        {
            casa.FechaAlquiler = DateTime.Now;
            var response = casasModel.ActualizarAlquilerCasa(casa);

            if (response != null)
            {
                return RedirectToAction("ConsultaCasas", "Casas");
            }
            else
            {
                TempData["Message"] = "No se ha podido obtener los datos de la casa";
                return View();
            }
        }
    }
}