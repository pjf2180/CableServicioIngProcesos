using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RegistroTrabajo
    {
        public int RegistroTrabajoId { get; set; }
        [ForeignKey("Tecnico")]
        public string TecnicoId { get; set; }
        public Tecnico Tecnico { get; set; }
        public int HorasTrabajadas { get; set; }
        public DateTime Fecha { get; set; }
        public bool status { get; set; }

        [NotMapped]
        public string status_str
        {
            get
            {
                return status  == true ? "Aprobado" : "Pendiente";
                   
            }
            set
            {
                status_str = value;
            }
        }
    }
}