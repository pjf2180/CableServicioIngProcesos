namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ok1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegistroDeSolicitudes", "estadoSolicitud", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegistroDeSolicitudes", "estadoSolicitud");
        }
    }
}
