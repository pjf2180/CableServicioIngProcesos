using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CableServicioController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public CableServicioController()
        {

        }


        public async Task<ApplicationUser> GetAppUser()
        {
            var um = UserManager;
            return await um.FindByNameAsync(User.Identity.Name);
           
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public async Task<ApplicationUser> getCurrentUser()
        {
            var user = await UserManager.FindByNameAsync(User.Identity.Name);
            return user;
        }

        // GET: CableServicio
        public ActionResult Index()
        {
            
            return View();
        }
    }
}