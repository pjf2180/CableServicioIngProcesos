namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ok11 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.RegistroTrabajoes", new[] { "Tecnico_TecnicoId" });
            DropColumn("dbo.RegistroTrabajoes", "TecnicoId");
            RenameColumn(table: "dbo.RegistroTrabajoes", name: "Tecnico_TecnicoId", newName: "TecnicoId");
            AlterColumn("dbo.RegistroTrabajoes", "TecnicoId", c => c.String(maxLength: 128));
            CreateIndex("dbo.RegistroTrabajoes", "TecnicoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.RegistroTrabajoes", new[] { "TecnicoId" });
            AlterColumn("dbo.RegistroTrabajoes", "TecnicoId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.RegistroTrabajoes", name: "TecnicoId", newName: "Tecnico_TecnicoId");
            AddColumn("dbo.RegistroTrabajoes", "TecnicoId", c => c.Int(nullable: false));
            CreateIndex("dbo.RegistroTrabajoes", "Tecnico_TecnicoId");
        }
    }
}
