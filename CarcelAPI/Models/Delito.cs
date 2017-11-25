using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarcelAPI.Models
{
    [Table("Delitos")]
    public class Delito
    {
        
        public int Id { get; set; }
        [MaxLength(30)]
        public string Nombre { get; set; }
        
        public int CondenaMinima { get; set; }
        
        public int CondenaMaxima { get; set; }
        public List<CondenaDelito> CondenaDelitos { get; set; }

    }
}