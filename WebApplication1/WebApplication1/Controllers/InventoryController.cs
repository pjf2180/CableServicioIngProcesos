using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class InventoryController : Controller
    {
        public InventoryManager manager;
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