namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Materiales",
                c => new
                    {
                        MaterialId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.MaterialId);
            
            CreateTable(
                "dbo.InventarioMateriales",
                c => new
                    {
                        InventarioMaterialId = c.Int(nullable: false),
                        Existencia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventarioMaterialId)
                .ForeignKey("dbo.Materiales", t => t.InventarioMaterialId)
                .Index(t => t.InventarioMaterialId);
            
            CreateTable(
                "dbo.TipoServicios",
                c => new
                    {
                        TipoServicioId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoServicioId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Ciudad = c.String(),
                        Colonia = c.String(),
                        Calle = c.String(),
                        CoidgoPostal = c.String(),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.RegistroDeSolicitudes",
                c => new
                    {
                        RegistroSolicitudId = c.Int(nullable: false, identity: true),
                        TipoServicioId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegistroSolicitudId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.TipoServicios", t => t.TipoServicioId, cascadeDelete: true)
                .Index(t => t.TipoServicioId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.RegistroTrabajoes",
                c => new
                    {
                        RegistroTrabajoId = c.Int(nullable: false, identity: true),
                        TecnicoId = c.Int(nullable: false),
                        HorasTrabajadas = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Tecnico_TecnicoId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RegistroTrabajoId)
                .ForeignKey("dbo.Tecnicos", t => t.Tecnico_TecnicoId)
                .Index(t => t.Tecnico_TecnicoId);
            
            CreateTable(
                "dbo.Tecnicos",
                c => new
                    {
                        TecnicoId = c.String(nullable: false, maxLength: 128),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TecnicoId)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RegistroTrabajoes", "Tecnico_TecnicoId", "dbo.Tecnicos");
            DropForeignKey("dbo.Tecnicos", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RegistroDeSolicitudes", "TipoServicioId", "dbo.TipoServicios");
            DropForeignKey("dbo.RegistroDeSolicitudes", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.InventarioMateriales", "InventarioMaterialId", "dbo.Materiales");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Tecnicos", new[] { "AppUser_Id" });
            DropIndex("dbo.RegistroTrabajoes", new[] { "Tecnico_TecnicoId" });
            DropIndex("dbo.RegistroDeSolicitudes", new[] { "ClienteId" });
            DropIndex("dbo.RegistroDeSolicitudes", new[] { "TipoServicioId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Clientes", new[] { "AppUser_Id" });
            DropIndex("dbo.InventarioMateriales", new[] { "InventarioMaterialId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Tecnicos");
            DropTable("dbo.RegistroTrabajoes");
            DropTable("dbo.RegistroDeSolicitudes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Clientes");
            DropTable("dbo.TipoServicios");
            DropTable("dbo.InventarioMateriales");
            DropTable("dbo.Materiales");
        }
    }
}
