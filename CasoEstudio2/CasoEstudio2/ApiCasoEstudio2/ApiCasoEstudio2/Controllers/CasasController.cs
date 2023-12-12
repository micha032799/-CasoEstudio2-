using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace ApiCasoEstudio2.Controllers
{
    public class CasasController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ConsultaCasas")]
        public List<CasasSistema> ConsultaCasas()
        {
            using (var context = new CasoEstudioMNEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var casas = context.CasasSistema.ToList();

                List<CasasSistema> listaFiltrada = casas
                    .Where(c => c.PrecioCasa >= 115000 && c.PrecioCasa < 180000)
                    .OrderBy(c => c.FechaAlquiler != null && c.UsuarioAlquiler != null)
                    .ThenBy(c => c.FechaAlquiler)
                    .ThenBy(c => c.UsuarioAlquiler)
                    .ToList();

                return listaFiltrada;
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("AlquilerCasas")]
        public List<System.Web.Mvc.SelectListItem> AlquilerCasas()
        {
            using (var context = new CasoEstudioMNEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var casas = (from x in context.CasasSistema
                             select x).ToList();

                var listaFiltrada = casas
                    .Where(c => c.PrecioCasa >= 115000 && c.PrecioCasa < 180000 && c.FechaAlquiler == null && c.UsuarioAlquiler == null)
                    .OrderBy(c => c.FechaAlquiler)
                    .ThenBy(c => c.UsuarioAlquiler)
                    .ToList();

                var respuesta = listaFiltrada.Select(item =>
                    new System.Web.Mvc.SelectListItem { Value = item.IdCasa.ToString(), Text = item.DescripcionCasa }
                ).ToList();

                return respuesta;
            }
        }




        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ConsultaCasa")]
        public CasasSistema ConsultaCasa(long IdCasa)
        {
            try
            {
                using (var context = new CasoEstudioMNEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    return (from x in context.CasasSistema
                            where x.IdCasa == IdCasa
                            select x).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("ActualizarAlquilerCasa")]
        public string ActualizarAlquilerCasa(CasasSistema casa)
        {
            try
            {
                using (var context = new CasoEstudioMNEntities())
                {
                    var data = context.CasasSistema.FirstOrDefault(x => x.IdCasa == casa.IdCasa);

                    if (data != null)
                    {
                        data.UsuarioAlquiler = casa.UsuarioAlquiler;
                        data.FechaAlquiler = casa.FechaAlquiler;

                        context.SaveChanges();

                        return "OK";
                    }
                    else
                    {
                        return "Casa no encontrada";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}