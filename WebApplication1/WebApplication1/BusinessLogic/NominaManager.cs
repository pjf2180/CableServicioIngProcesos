using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.BusinessLogic
{
    public class NominaManager:CableServicioManager
    {

        public void ActualizarRegsitro(RegistroTrabajo registro)
        {
            registro.status = true;
            context.Entry(registro).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public ICollection<RegistroTrabajo> GetRegistrosDeTrabajo()
        {
            var r = context.RegistrosDeTrabajo.ToList();
            return r;
        }
        public RegistroTrabajo GetRegistroDeTrabajo(int Id)
        {
            var r = context.RegistrosDeTrabajo.Where(x=>x.RegistroTrabajoId==Id) .FirstOrDefault();
            return r;
        }
    }
}