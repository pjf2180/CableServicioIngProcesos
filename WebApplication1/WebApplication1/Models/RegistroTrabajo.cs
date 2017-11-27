using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RegistroTrabajo
    {
        public int RegistroTrabajoId { get; set; }
        public int TecnicoId { get; set; }
        public Tecnico Tecnico { get; set; }
        public int HorasTrabajadas { get; set; }
        public DateTime Fecha { get; set; }
    }
}