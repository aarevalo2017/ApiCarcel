using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarcelAPI.Models
{
    [Table("Jueces")]
    public class Juez
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public bool Sexo { get; set; }
        public string Domicilio { get; set; }
        public List<Condena> Condenas { get; set; }
    }
}