using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CarcelAPI.Models
{
    public class CarcelDBContext:DbContext
    {
        public DbSet<Preso> Presos { get; set; }

        public DbSet<Delito> Delitos { get; set; }

        public DbSet<Juez> Jueces { get; set; }

        public DbSet<Condena> Condenas { get; set; }

        public DbSet<CondenaDelito> CondenaDelitos { get; set; }
    }
}