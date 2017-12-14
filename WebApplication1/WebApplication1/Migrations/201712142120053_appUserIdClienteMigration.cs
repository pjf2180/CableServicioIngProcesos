namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appUserIdClienteMigration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Clientes", name: "AppUser_Id", newName: "AppUserId");
            RenameIndex(table: "dbo.Clientes", name: "IX_AppUser_Id", newName: "IX_AppUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Clientes", name: "IX_AppUserId", newName: "IX_AppUser_Id");
            RenameColumn(table: "dbo.Clientes", name: "AppUserId", newName: "AppUser_Id");
        }
    }
}
