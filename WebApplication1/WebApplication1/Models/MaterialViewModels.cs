using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class MaterialViewModels
    {
        [Required]
        [Display(Name = "Material")]
        public ICollection<InventarioMaterial> TipoMaterial { get; set; }
    }
}