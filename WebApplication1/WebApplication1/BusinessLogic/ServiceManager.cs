
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace BusinessLogic
{
    public class ServiceManager:CableServicioManager
    {
        public void ServiceRequest(int tipoServicioId,string userId)
        {
            if (context.CatalogoServicios.Where(x => x.TipoServicioId == tipoServicioId).Count() == 0)
                throw new Exception();
            int clienteId = context.Clientes.Where(x => x.AppUser.Id == userId).FirstOrDefault().ClienteId;
            RegistroSolicitud solicitud = new RegistroSolicitud
            { ClienteId = clienteId, TipoServicioId = tipoServicioId };

            context.RegistrosDeSolicitud.Add(solicitud);
            context.SaveChanges();
        }
        public void AgregarRegistroDeTrabajo(RegistroTrabajo  registro)
        {
            context.RegistrosDeTrabajo.Add(registro);
            context.SaveChanges();
        }
        public RegistroSolicitud GetRegsitroSolicitud(int id)
        {
            return context.RegistrosDeSolicitud.Where(x => x.RegistroSolicitudId == id).FirstOrDefault();
        }
        public ICollection<TipoServicio> GetCatalogoServicios()
        {
            return context.CatalogoServicios.ToList();
        }
        public ICollection<RegistroSolicitud> GetSolicitudes()
        {
            return context.RegistrosDeSolicitud.ToList(); 
        }
    }
}
