using CasoEstudio2.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace CasoEstudio2.Models
{
    public class CasasModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public List<CasaEnt> ConsultaCasas()
        {

            using (var client = new HttpClient())
            {
                var url = urlApi + "ConsultaCasas";
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<CasaEnt>>().Result;
            }
        }
        public List<SelectListItem> AlquilerCasas()
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "AlquilerCasas";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            }
        }

        public CasaEnt ConsultaCasa(long IdCasa)
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ConsultaCasa?IdCasa=" + IdCasa;
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<CasaEnt>().Result;
            }
        }
    }
}