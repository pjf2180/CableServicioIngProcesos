using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.View_models
{
    public class ListaDeSolicitudesViewModel
    {
        public ICollection<RegistroSolicitud> Solicitudes { get; set; }
    }
}