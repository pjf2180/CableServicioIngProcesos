using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using System.Threading.Tasks;
using WebApplication1.View_models;

namespace WebApplication1.Controllers
{
    public class AdministradorController : CableServicioController
    {
        public ServiceManager _serviceManager { get; set; }
        public AdministradorController() : base()
        {
            _serviceManager = new ServiceManager();
        }
        [HttpGet]
        public ActionResult VerDetails(int idSolicitud)
        {
            var vm = new DetalleNominasViewModel();
            //vm.Trabajo = _serviceManager.GetRegsitroSolicitud(idSolicitud);

            return View(vm);
        }
        // GET: Administrador
        public ActionResult Trabajos()
        {
            var vm = new ListaDeNominasViewModel();
            //var user = await getCurrentUser();
            //vm.Trabajos = _serviceManager.GetSolicitudes().Where(s => s.Cliente.AppUserId == user.Id).ToList();
            return View(vm);
        }
    }
}