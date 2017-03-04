namespace AICRDWEB.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregandonuevosCampoImagenAsociacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asociaciones", "LogoAsociacion", c => c.String(nullable: false, maxLength: 120));
            AddColumn("dbo.Asociaciones", "AlternateText", c => c.String(maxLength: 100));
            DropColumn("dbo.Asociaciones", "Logo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Asociaciones", "Logo", c => c.String());
            DropColumn("dbo.Asociaciones", "AlternateText");
            DropColumn("dbo.Asociaciones", "LogoAsociacion");
        }
    }
}
