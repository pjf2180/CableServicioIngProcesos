
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace BusinessLogic
{
    public class InventoryManager : CableServicioManager
    {
        public void AddMaterialToInventory(int quantity,int tipoMaterialId)
        {
            InventarioMaterial inventario = context.InventarioMateriales
                .Where(x => x.InventarioMaterialId == tipoMaterialId).FirstOrDefault();
            inventario.Existencia -= quantity;
            context.Entry(inventario).State = EntityState.Modified;
            context.SaveChanges();
        }
        public Material RequestMaterial(int quantity,int tipoMaterialId)
        {
            InventarioMaterial inventario = context.InventarioMateriales
                .Where(x => x.InventarioMaterialId == tipoMaterialId).FirstOrDefault();
            if (quantity > inventario.Existencia)
                throw new Exception();
            inventario.Existencia -= quantity;
            context.Entry(inventario).State = EntityState.Modified;
            context.SaveChanges();
            return inventario.Material;
        }
        public ICollection<InventarioMaterial> GetInventario()
        {
            var inventario = 
            context.InventarioMateriales.ToList();

            return inventario;
        }
    }
}
