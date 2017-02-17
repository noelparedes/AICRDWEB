namespace AICRDWEB.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizandoFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Circuitos", "IdIglesia", "dbo.Iglesias");
            DropIndex("dbo.Circuitos", new[] { "IdIglesia" });
            AddColumn("dbo.Iglesias", "IdCircuito", c => c.Int(nullable: false));
            AddColumn("dbo.Miembros", "IdIglesia", c => c.Int(nullable: false));
            CreateIndex("dbo.Iglesias", "IdCircuito");
            CreateIndex("dbo.Miembros", "IdIglesia");
            AddForeignKey("dbo.Iglesias", "IdCircuito", "dbo.Circuitos", "IdCircuito", cascadeDelete: true);
            AddForeignKey("dbo.Miembros", "IdIglesia", "dbo.Iglesias", "IdIglesia", cascadeDelete: true);
            DropColumn("dbo.Circuitos", "IdIglesia");
            DropColumn("dbo.Miembros", "IdImagen");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Miembros", "IdImagen", c => c.Int(nullable: false));
            AddColumn("dbo.Circuitos", "IdIglesia", c => c.Int(nullable: false));
            DropForeignKey("dbo.Miembros", "IdIglesia", "dbo.Iglesias");
            DropForeignKey("dbo.Iglesias", "IdCircuito", "dbo.Circuitos");
            DropIndex("dbo.Miembros", new[] { "IdIglesia" });
            DropIndex("dbo.Iglesias", new[] { "IdCircuito" });
            DropColumn("dbo.Miembros", "IdIglesia");
            DropColumn("dbo.Iglesias", "IdCircuito");
            CreateIndex("dbo.Circuitos", "IdIglesia");
            AddForeignKey("dbo.Circuitos", "IdIglesia", "dbo.Iglesias", "IdIglesia", cascadeDelete: true);
        }
    }
}
