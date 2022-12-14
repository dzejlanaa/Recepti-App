using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recepti.Modul1.ViewModels
{
    public class ReceptiGetAllVM
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public string opis { get; set; }
        public string sastojci { get; set; }
        public DateTime created_time { get; set; }
        public string image { get; set; }
        
    }
}
