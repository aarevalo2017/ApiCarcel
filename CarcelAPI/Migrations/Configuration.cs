namespace CarcelAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CarcelAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CarcelAPI.Models.CarcelDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarcelAPI.Models.CarcelDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Presos.AddOrUpdate(
                p => p.Nombre,
                new Preso { Rut = "14.652.659-1", Nombre = "Brayatan", Apellido = "Andalaaar", FechaNacimiento = DateTime.Parse("22-05-1970"), Domicilio = "Concha y Toro 654", Sexo = true },
                new Preso { Rut = "12.635.632-8", Nombre = "El Bairon", Apellido = "Tepaseo", FechaNacimiento = DateTime.Parse("22-05-1980"), Domicilio = "Almeida 5487", Sexo = true },
                new Preso { Rut = "18.235.458-4", Nombre = "Deyanira", Apellido = "Lacomemoco", FechaNacimiento = DateTime.Parse("22-05-1990"), Domicilio = "El Cairo 748", Sexo = true }
            );
            context.Jueces.AddOrUpdate(
                j => j.Nombre,
                new Juez { Nombre = "Roberto Perez", Rut = "11.111.111-1", Sexo = true, Domicilio = "Las Cruces 123" },
                new Juez { Nombre = "Jorge Rojas", Rut = "22.222.222-2", Sexo = true, Domicilio = "Santo Domingo 421" },
                new Juez { Nombre = "Pedro Jara", Rut = "33.333.333-3", Sexo = true, Domicilio = "Catedral 654" }
            );
            context.Delitos.AddOrUpdate(
                c => c.Nombre,
               new Delito { Nombre = "Homicidio", CondenaMinima = 5, CondenaMaxima = 20 },
               new Delito { Nombre = "Femicidio", CondenaMinima = 5, CondenaMaxima = 20 },
               new Delito { Nombre = "Robo con intimidacion", CondenaMinima = 1, CondenaMaxima = 12 },
               new Delito { Nombre = "Robo en lugar no habitado", CondenaMinima = 1, CondenaMaxima = 5 },
               new Delito { Nombre = "Cohecho", CondenaMinima = 5, CondenaMaxima = 8 }
            );
            //context.Condenas.AddOrUpdate(
            //        c => c.Id,
            //        new Condena { FechaInicioCondena = DateTime.Parse("01-09-2017"), FechaCondena = DateTime.Parse("01-10-2017"), PresoId = 1, JuezId = 1 },
            //        new Condena { FechaInicioCondena = DateTime.Parse("01-10-2017"), FechaCondena = DateTime.Parse("01-11-2017"), PresoId = 2, JuezId = 2 },
            //        new Condena { FechaInicioCondena = DateTime.Parse("01-11-2017"), FechaCondena = DateTime.Parse("01-12-2017"), PresoId = 3, JuezId = 3 }
            //    );
            //context.CondenaDelitos.AddOrUpdate(
            //        cd => cd.Id,
            //        new CondenaDelito { CondenaId = 1, DelitoId = 1, TiempoCondena = 10},
            //        new CondenaDelito { CondenaId = 1, DelitoId = 2, TiempoCondena = 10},
            //        new CondenaDelito { CondenaId = 2, DelitoId = 3, TiempoCondena = 7},
            //        new CondenaDelito { CondenaId = 2, DelitoId = 4, TiempoCondena = 3},
            //        new CondenaDelito { CondenaId = 3, DelitoId = 5, TiempoCondena = 6}
            //    );
        }
    }
}
