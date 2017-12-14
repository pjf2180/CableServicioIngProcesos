using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TipoServicio
    {
       public int TipoServicioId { get; set; }
       public string Descripcion { get; set; }
       public Decimal Precio { get; set; }
      
    }
}