using BusinessLogic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.View_models;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class TecnicoController : Controller
    {

        public ServiceManager _serviceManager { get; set; }
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
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                UserManager = value;
            }
        }
        public TecnicoController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _serviceManager = new ServiceManager();
        }
        public TecnicoController()
        {
            _serviceManager = new ServiceManager();
        }
        public async Task<ApplicationUser> getCurrentUser()
        {
            var user = await UserManager.FindByNameAsync(User.Identity.Name);
            return user;
        }
        [HttpGet]
        public  ActionResult ViewDetails(int idSolicitud)
        {
            var vm = new DetalleSolicitudViewModel();
            vm.Solicitud = _serviceManager.GetRegsitroSolicitud(idSolicitud);

            return View(vm);
        }
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }
        // GET: Tecnico
        public async Task<ActionResult> Solicitudes()
        {
            var vm = new ListaDeSolicitudesViewModel();
            vm.Solicitudes = _serviceManager.GetSolicitudes();
               
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ViewDetails(DetalleSolicitudViewModel registro)
        {
            ApplicationDbContext context;
            context = new ApplicationDbContext();
            RegistroSolicitud estado = context.RegistrosDeSolicitud.Where(x => x.RegistroSolicitudId == registro.Solicitud.RegistroSolicitudId).FirstOrDefault();
            estado.EstadoSolicitud = true;
            context.Entry(estado).State = EntityState.Modified;
            context.SaveChanges();
            return View("Index");
        }
    }
}