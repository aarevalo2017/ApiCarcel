using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarcelAPI.Models
{
    [Table("Jueces")]
    public class Juez
    {
        
        public int Id { get; set; }
        [MaxLength(30)]
        public string Nombre { get; set; }
        [MaxLength(30)]
        public string Rut { get; set; }
        
        public bool Sexo { get; set; }
        [MaxLength(30)]
        public string Domicilio { get; set; }
        public List<Condena> Condenas { get; set; }
    }
}