using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class MaterialViewModel
    {
        
        [Display(Name = "InventarioMateriales")]
        public ICollection<InventarioMaterial> InventarioMateriales { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public Dictionary<string,string> Cantidades_Solicitadas { get; set; }
    }
}