namespace AICRDWEB.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletingCascade : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asociaciones",
                c => new
                    {
                        IdAsociacion = c.Int(nullable: false, identity: true),
                        Logo = c.Byte(nullable: false),
                        NombreAsociacion = c.String(nullable: false, maxLength: 30),
                        LemaAsociacion = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.IdAsociacion);
            
            CreateTable(
                "dbo.Cargos",
                c => new
                    {
                        IdCargo = c.Int(nullable: false, identity: true),
                        Cargo = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdCargo);
            
            CreateTable(
                "dbo.Circuitos",
                c => new
                    {
                        IdCircuito = c.Int(nullable: false, identity: true),
                        IdRegion = c.Int(nullable: false),
                        IdIglesia = c.Int(nullable: false),
                        NombreCircuito = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.IdCircuito)
                .ForeignKey("dbo.Iglesias", t => t.IdIglesia, cascadeDelete: true)
                .ForeignKey("dbo.Regiones", t => t.IdRegion, cascadeDelete: true)
                .Index(t => t.IdRegion)
                .Index(t => t.IdIglesia);
            
            CreateTable(
                "dbo.Iglesias",
                c => new
                    {
                        IdIglesia = c.Int(nullable: false, identity: true),
                        NombreIglesia = c.String(nullable: false, maxLength: 30),
                        Descripcion = c.String(maxLength: 150),
                        Fundador = c.String(maxLength: 50),
                        FechaFundacion = c.DateTime(nullable: false),
                        CantidadMiembro = c.Int(nullable: false),
                        Direccion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdIglesia);
            
            CreateTable(
                "dbo.Regiones",
                c => new
                    {
                        IdRegion = c.Int(nullable: false, identity: true),
                        NombreRegion = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.IdRegion);
            
            CreateTable(
                "dbo.ImagenesMiembro",
                c => new
                    {
                        IdImagen = c.Int(nullable: false, identity: true),
                        NombreImagen = c.String(maxLength: 255),
                        Size = c.Int(nullable: false),
                        ImageData = c.Binary(),
                    })
                .PrimaryKey(t => t.IdImagen);
            
            CreateTable(
                "dbo.Miembros",
                c => new
                    {
                        IdMiembro = c.Int(nullable: false, identity: true),
                        IdCargo = c.Int(nullable: false),
                        IdAsociacion = c.Int(nullable: false),
                        IdImagen = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                        Nombres = c.String(nullable: false, maxLength: 50),
                        Apellidos = c.String(nullable: false, maxLength: 50),
                        Direccion = c.String(nullable: false, maxLength: 100),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Telefono = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.IdMiembro)
                .ForeignKey("dbo.Asociaciones", t => t.IdAsociacion, cascadeDelete: true)
                .ForeignKey("dbo.Cargos", t => t.IdCargo, cascadeDelete: true)
                .Index(t => t.IdCargo)
                .Index(t => t.IdAsociacion);
            
            CreateTable(
                "dbo.RegistroConvenciones",
                c => new
                    {
                        IdRegistro = c.Int(nullable: false, identity: true),
                        IdMiembro = c.Int(),
                        IdCircuitos = c.Int(),
                        IdIglesia = c.Int(),
                        Costo = c.String(),
                        FechaRegistro = c.DateTime(nullable: false),
                        Exhonerado = c.Boolean(nullable: false),
                        Observaciones = c.String(maxLength: 800),
                        Nombres = c.String(nullable: false, maxLength: 50),
                        Apellidos = c.String(nullable: false, maxLength: 50),
                        Direccion = c.String(nullable: false, maxLength: 100),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Telefono = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.IdRegistro)
                .ForeignKey("dbo.Circuitos", t => t.IdCircuitos)
                .ForeignKey("dbo.Iglesias", t => t.IdIglesia)
                .ForeignKey("dbo.Miembros", t => t.IdMiembro)
                .Index(t => t.IdMiembro)
                .Index(t => t.IdCircuitos)
                .Index(t => t.IdIglesia);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegistroConvenciones", "IdMiembro", "dbo.Miembros");
            DropForeignKey("dbo.RegistroConvenciones", "IdIglesia", "dbo.Iglesias");
            DropForeignKey("dbo.RegistroConvenciones", "IdCircuitos", "dbo.Circuitos");
            DropForeignKey("dbo.Miembros", "IdCargo", "dbo.Cargos");
            DropForeignKey("dbo.Miembros", "IdAsociacion", "dbo.Asociaciones");
            DropForeignKey("dbo.Circuitos", "IdRegion", "dbo.Regiones");
            DropForeignKey("dbo.Circuitos", "IdIglesia", "dbo.Iglesias");
            DropIndex("dbo.RegistroConvenciones", new[] { "IdIglesia" });
            DropIndex("dbo.RegistroConvenciones", new[] { "IdCircuitos" });
            DropIndex("dbo.RegistroConvenciones", new[] { "IdMiembro" });
            DropIndex("dbo.Miembros", new[] { "IdAsociacion" });
            DropIndex("dbo.Miembros", new[] { "IdCargo" });
            DropIndex("dbo.Circuitos", new[] { "IdIglesia" });
            DropIndex("dbo.Circuitos", new[] { "IdRegion" });
            DropTable("dbo.RegistroConvenciones");
            DropTable("dbo.Miembros");
            DropTable("dbo.ImagenesMiembro");
            DropTable("dbo.Regiones");
            DropTable("dbo.Iglesias");
            DropTable("dbo.Circuitos");
            DropTable("dbo.Cargos");
            DropTable("dbo.Asociaciones");
        }
    }
}
