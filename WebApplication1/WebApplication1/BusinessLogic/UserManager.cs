using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.BusinessLogic
{
    public class ClienteUserManager:CableServicioManager
    {
        public void AddClienteUser(Cliente cliente)
        {
            try
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }
    }
}