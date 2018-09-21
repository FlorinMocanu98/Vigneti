using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vigneti.Models
{
    // Enum per definire tutti i tipi di vino prodotti nei vigneti
    public enum TypeW { Bianco, Rosso, Rosato, Spumante, Arancione, Novello, Passito, Barricato}
    public class Wine
    {
        // Classe Vino
        public int WineID { get; set; }
        public TypeW Type { get; set; }


        // Un tipo di vino può essere prodotto in più vigneti
        public ICollection<Vineyard> Vineyards { get; set; }
        
    }
}
