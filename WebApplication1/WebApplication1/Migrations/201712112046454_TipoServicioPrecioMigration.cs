namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoServicioPrecioMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TipoServicios", "Precio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TipoServicios", "Precio");
        }
    }
}
