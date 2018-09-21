using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vigneti.Models.VineyardViewModel
{
    public class HomeIndexData
    {
        public IEnumerable<Vineyard> Vineyards { get; set; }
        public IEnumerable<VineGrower>  VineGrowers { get; set; }
        public IEnumerable<Wine>  Wines { get; set; }
    }
}
