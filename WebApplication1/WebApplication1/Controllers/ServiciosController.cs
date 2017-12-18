using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ServiciosController : CableServicioController
    {
        private ServiceManager _serviceManager;

        public ServiciosController():base()
        {
            _serviceManager = new ServiceManager();
        }
        
        public ActionResult Paquetes()
        {
            var servicios = _serviceManager.GetCatalogoServicios();

            return View(new CreditViewModels { Servicios = servicios});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Paquetes(CreditViewModels vm)
        {
            if(!ModelState.IsValid)
            {
                return View(vm);
            }
            var user = await GetAppUser();
            string appUserId = user.Id;
           _serviceManager.ServiceRequest(vm.selectedService, appUserId);
            return View("Listo");
        }
    }
}