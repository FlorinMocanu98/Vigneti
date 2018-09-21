using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vigneti.Models
{
    public class VineGrower
    {
        // Classe viticoltore, relazione 1...* con i vigneti
        
        public int ID { get; set; }

        public string FullName { get; set; }

        public ICollection<Vineyard> Vineyards { get; set; }
    }
}
