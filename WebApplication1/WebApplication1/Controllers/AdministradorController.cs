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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class AdministradorController : Controller
    {
        public ServiceManager _serviceManager { get; set; }
        public NominaManager _nomManager { get; set; }
        public AdministradorController() 
        {
            _serviceManager = new ServiceManager();
            _nomManager = new NominaManager();
        }
        public AdministradorController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return  HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                SignInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return  HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                UserManager = value;
            }
        }
        [HttpGet]
        public ActionResult VerDetalles(int idSolicitud)
        {
            RegistroTrabajo rt = _nomManager.GetRegistroDeTrabajo(idSolicitud);
            DetalleNominasViewModel vm = new DetalleNominasViewModel { isApproved = rt.status, Trabajo = rt };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Aprobar(DetalleNominasViewModel registro)
        {

           // _nomManager.ActualizarRegsitro(registro);

            return View(registro);
        }
        // GET: Administrador
        public ActionResult Nomina()
        {
            var nominas = _nomManager.GetRegistrosDeTrabajo();
            return View(nominas);

        }
        public ActionResult Index()
        {
            
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VerDetalles(DetalleNominasViewModel registro)
        {
            ApplicationDbContext context;
            context = new ApplicationDbContext();
            RegistroTrabajo estado = context.RegistrosDeTrabajo.Where(x => x.RegistroTrabajoId == registro.Trabajo.RegistroTrabajoId).FirstOrDefault();
            estado.status = true;
            context.Entry(estado).State = EntityState.Modified;
            context.SaveChanges();
            return View("Index");
        }
    }
}