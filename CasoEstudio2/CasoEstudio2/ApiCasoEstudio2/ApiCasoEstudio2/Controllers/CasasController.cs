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
        public List<CasasSistema> AlquilerCasas()
        {
            using (var context = new CasoEstudioMNEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var casasNoAlquiladas = context.CasasSistema
                    .Where(c => c.FechaAlquiler == null && c.UsuarioAlquiler == null)
                    .ToList();

                return casasNoAlquiladas;
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
    }
}