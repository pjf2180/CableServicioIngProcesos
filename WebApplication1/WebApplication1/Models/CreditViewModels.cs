using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CreditViewModels
    {
        [Required]
        [Display(Name = "Nombre de titular")]
        public string Titular { get; set; }

        [Required]
        [Display(Name = "CLABE (16 digitos)")]
        public string Clabe { get; set; }

        [Required]
        [Display(Name = "Clave (3 digitos)")]
        public string Clave { get; set; }

        [Required]
        [Display(Name = "Servicios")]
        public ICollection<TipoServicio> Servicios { get; set; }
    }
}