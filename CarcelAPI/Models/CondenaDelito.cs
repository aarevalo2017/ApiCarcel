using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarcelAPI.Models
{
    public class CondenaDelito
    {
        public int Id { get; set; }

        public int? CondenaId { get; set; }
        public Condena Condena { get; set; }

        public int? DelitoId { get; set; }
        public Delito Delito { get; set; }
          
        public int TiempoCondena { get; set; }

    }
}