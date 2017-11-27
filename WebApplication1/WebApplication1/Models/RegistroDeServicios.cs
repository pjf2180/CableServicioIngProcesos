using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RegistroDeServicio
    {
        public RegistroDeServicio RegistroDeServicioId { get; set; }

        public Tecnico Tecnico { get; set; }
        public Cliente Cliente { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int TipoServicioId { get; set; }
        public TipoServicio TipoServicio { get; set; }
    }
}