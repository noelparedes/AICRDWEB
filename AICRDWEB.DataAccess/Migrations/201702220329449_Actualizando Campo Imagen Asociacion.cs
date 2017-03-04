namespace AICRDWEB.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizandoCampoImagenAsociacion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Asociaciones", "Logo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Asociaciones", "Logo", c => c.Byte(nullable: false));
        }
    }
}
