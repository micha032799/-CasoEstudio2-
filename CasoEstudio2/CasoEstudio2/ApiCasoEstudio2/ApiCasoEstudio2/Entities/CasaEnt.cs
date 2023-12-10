using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiCasoEstudio2.Entities
{
    public class CasaEnt
    {
        public long IdCasa { get; set; }

        public string DescripcionCasa { get; set; }

        [Range( 11500.00, 180000.00)]
        public decimal PrecioCasa { get; set; }

        public string UsuarioAlquiler { get; set; }
      
        public DateTime FechaAlquiler { get; set; }
    }
}