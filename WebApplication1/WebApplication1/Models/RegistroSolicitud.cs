using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [Table("RegistroDeSolicitudes")]
    public class RegistroSolicitud
    {
        public int RegistroSolicitudId { get; set; }

        public bool EstadoSolicitud { get; set; }
        public int TipoServicioId { get; set; }
        public virtual TipoServicio TipoServicio { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}