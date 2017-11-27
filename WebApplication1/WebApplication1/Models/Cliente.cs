using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public string CoidgoPostal { get; set; }

        public ApplicationUser AppUser { get; set; }
        public virtual ICollection<RegistroSolicitud> RegistrosDeSolicitud { get; set; }
    }
}