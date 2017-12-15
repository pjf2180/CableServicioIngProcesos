using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using System.Threading.Tasks;
using WebApplication1.View_models;
using WebApplication1.BusinessLogic;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdministradorController : CableServicioController
    {
        public ServiceManager _serviceManager { get; set; }
        public NominaManager _nomManager { get; set; }
        public AdministradorController() : base()
        {
            _serviceManager = new ServiceManager();
            _nomManager = new NominaManager();
        }
        [HttpGet]
        public ActionResult VerDetalles(int idSolicitud)
        {
            RegistroTrabajo vm = _nomManager.GetRegistroDeTrabajo(idSolicitud);

            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Aprobar(RegistroTrabajo registro)
        {
            _nomManager.ActualizarRegsitro(registro);

            return View(registro);
        }
        // GET: Administrador
        public ActionResult Nomina()
        {
            var nominas = _nomManager.GetRegistrosDeTrabajo();
            return View(nominas);

        }
    }
}