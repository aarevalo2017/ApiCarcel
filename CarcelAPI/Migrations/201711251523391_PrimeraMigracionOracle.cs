namespace CarcelAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeraMigracionOracle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "carcel.CondenaDelitos",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        CondenaId = c.Decimal(precision: 10, scale: 0),
                        DelitoId = c.Decimal(precision: 10, scale: 0),
                        TiempoCondena = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("carcel.Condenas", t => t.CondenaId)
                .ForeignKey("carcel.Delitos", t => t.DelitoId)
                .Index(t => t.CondenaId)
                .Index(t => t.DelitoId);
            
            CreateTable(
                "carcel.Condenas",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        FechaInicioCondena = c.DateTime(nullable: false),
                        FechaCondena = c.DateTime(nullable: false),
                        PresoId = c.Decimal(precision: 10, scale: 0),
                        JuezId = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("carcel.Jueces", t => t.JuezId)
                .ForeignKey("carcel.Presos", t => t.PresoId)
                .Index(t => t.PresoId)
                .Index(t => t.JuezId);
            
            CreateTable(
                "carcel.Jueces",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Nombre = c.String(maxLength: 30),
                        Rut = c.String(maxLength: 30),
                        Sexo = c.Decimal(nullable: false, precision: 1, scale: 0),
                        Domicilio = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "carcel.Presos",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Rut = c.String(maxLength: 30),
                        Nombre = c.String(maxLength: 30),
                        Apellido = c.String(maxLength: 30),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Domicilio = c.String(maxLength: 30),
                        Sexo = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "carcel.Delitos",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Nombre = c.String(maxLength: 30),
                        CondenaMinima = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CondenaMaxima = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("carcel.CondenaDelitos", "DelitoId", "carcel.Delitos");
            DropForeignKey("carcel.Condenas", "PresoId", "carcel.Presos");
            DropForeignKey("carcel.Condenas", "JuezId", "carcel.Jueces");
            DropForeignKey("carcel.CondenaDelitos", "CondenaId", "carcel.Condenas");
            DropIndex("carcel.Condenas", new[] { "JuezId" });
            DropIndex("carcel.Condenas", new[] { "PresoId" });
            DropIndex("carcel.CondenaDelitos", new[] { "DelitoId" });
            DropIndex("carcel.CondenaDelitos", new[] { "CondenaId" });
            DropTable("carcel.Delitos");
            DropTable("carcel.Presos");
            DropTable("carcel.Jueces");
            DropTable("carcel.Condenas");
            DropTable("carcel.CondenaDelitos");
        }
    }
}
