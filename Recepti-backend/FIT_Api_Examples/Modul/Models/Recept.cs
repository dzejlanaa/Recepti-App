using System;
using System.ComponentModel.DataAnnotations;

namespace Recepti.Modul1.Models
{
    public class Recept
    { 
        [Key]
        public int id { get; set; }
        public string naziv { get; set; }
        public string opis { get; set; }
        public string sastojci { get; set; }
        public DateTime created_time { get; set; }
        public string image { get; set; }
    }
}
