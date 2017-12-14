using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.View_models;

namespace WebApplication1.Controllers
{
    public class TecnicoController : CableServicioController
    {

        public ServiceManager _serviceManager { get; set; }
        public TecnicoController():base()
        {
            _serviceManager = new ServiceManager();
        }
        [HttpGet]
        public  ActionResult ViewDetails(int idSolicitud)
        {
            var vm = new DetalleSolicitudViewModel();
            vm.Solicitud = _serviceManager.GetRegsitroSolicitud(idSolicitud);

            return View(vm);
        }
        // GET: Tecnico
        public async Task<ActionResult> Solicitudes()
        {
            var vm = new ListaDeSolicitudesViewModel();
            var user = await getCurrentUser();
            vm.Solicitudes = _serviceManager.GetSolicitudes()
                .Where(s=>s.Cliente.AppUserId==user.Id).ToList();
            return View(vm);
        }
    }
}