using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarcelAPI.Models
{
    public class CondenaDelito
    {
        public int Id { get; set; }
        public List<Condena> Condena { get; set; }
        public int? DelitoId { get; set; }
        public int? CondenaId { get; set; }
    }
}