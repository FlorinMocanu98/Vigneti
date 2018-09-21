using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vigneti.Models
{
    public class Vineyard
    {
        // Classe Vigneto

        public int VineyardID { get; set; }

        [Display(Name = "Dimensione")]
        public double Dimension { get; set; }

        [Display(Name = "Umidità")]
        public double Humidity { get; set; }

        // Sarà relazionata ad un viticoltore
        public int VineGrowerID { get; set; }

        public int WineID { get; set; }
        [Display(Name = "Vigneto di :")]
        public VineGrower VineGrower { get; set; }
        [Display(Name = "Vino prodotto")]
        public Wine Wine { get; set; }

    }
}
