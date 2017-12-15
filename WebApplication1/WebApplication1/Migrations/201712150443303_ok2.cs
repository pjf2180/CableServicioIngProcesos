namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ok2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegistroTrabajoes", "status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegistroTrabajoes", "status");
        }
    }
}
