using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [Table("Materiales")]
    public class Material
    {

        public int MaterialId { get; set; }

        public string Descripcion { get; set; }


       public InventarioMaterial InventarioMaterial { get; set; }

    }
}