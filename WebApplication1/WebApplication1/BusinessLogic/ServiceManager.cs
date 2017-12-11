
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
        public void ServiceRequest(int tipoServicioId,int clienteId)
        {
            if (context.CatalogoServicios.Where(x => x.TipoServicioId == tipoServicioId).Count() == 0)
                throw new Exception();
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
        public ICollection<TipoServicio> GetCatalogoServicios()
        {
            return context.CatalogoServicios.ToList();
        }
    }
}
