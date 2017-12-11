namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebApplication1.Models.ApplicationDbContext";
        }

        protected override void Seed(WebApplication1.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.CatalogoServicios.AddOrUpdate(
                new Models.TipoServicio { Descripcion = "Telefonía" ,Precio = 100 },
                new Models.TipoServicio { Descripcion = "Televisión" ,Precio = 300},
                new Models.TipoServicio { Descripcion = "Telefonía + Televisión",Precio = 350},
                new Models.TipoServicio { Descripcion = "Internet 10 megas",Precio = 300},
                new Models.TipoServicio { Descripcion = "Inteternet 20 Megas",Precio = 350 },
                new Models.TipoServicio { Descripcion = "Telefonía + Internet 20 Megas",Precio=380 },
                new Models.TipoServicio { Descripcion = "Televisión + Internet 20 Megas", Precio = 450},
                new Models.TipoServicio { Descripcion = "Televisión + Telefoníia + Internet 20 Megas" ,Precio = 500}
                );
        }
    }
}
