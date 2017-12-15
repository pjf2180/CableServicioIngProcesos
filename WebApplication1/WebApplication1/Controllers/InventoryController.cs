using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using  System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class InventoryController : Controller
    {
        public InventoryManager manager;
        private MaterialViewModel materialVm;
        [HttpGet]
        public ActionResult Solicitud()
        {
            materialVm = new MaterialViewModel();
            materialVm.InventarioMateriales = manager.GetInventario();
            materialVm.Cantidades_Solicitadas = new Dictionary<string, string>();
            foreach(InventarioMaterial item in materialVm.InventarioMateriales)
            {
                materialVm.Cantidades_Solicitadas.Add(item.Material.MaterialId.ToString(), "0");
            }
            return View(materialVm);
        }

        //POST: Inventory
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public  ActionResult Solicitud(MaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            foreach (var item in model.Cantidades_Solicitadas)
                manager.RequestMaterial(Convert.ToInt32(item.Value), Convert.ToInt32(item.Key));

            return RedirectToAction("Index","Tecnico");

        }

        public InventoryController()
        {
            manager = new InventoryManager();
        }
        // GET: Inventory
        public ActionResult Index()
        {
            List<Material> materiales = manager.context.CatalogoMateriales.ToList();
            return View(materiales);
        }
    }
}