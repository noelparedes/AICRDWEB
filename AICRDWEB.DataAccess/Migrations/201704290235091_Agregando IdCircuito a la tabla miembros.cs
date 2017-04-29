namespace AICRDWEB.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregandoIdCircuitoalatablamiembros : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Miembros", "IdCircuito", c => c.Int(nullable: false));
            CreateIndex("dbo.Miembros", "IdCircuito");
            AddForeignKey("dbo.Miembros", "IdCircuito", "dbo.Circuitos", "IdCircuito", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Miembros", "IdCircuito", "dbo.Circuitos");
            DropIndex("dbo.Miembros", new[] { "IdCircuito" });
            DropColumn("dbo.Miembros", "IdCircuito");
        }
    }
}
