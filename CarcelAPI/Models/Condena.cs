using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarcelAPI.Models
{
    public class Condena
    {
        public int Id { get; set; }
        public DateTime FechaInicioCondena { get; set; }
        public DateTime FechaCondena { get; set; }
        public int? PresoId { get; set; }
        public int JuezId { get; set; }
    }
}