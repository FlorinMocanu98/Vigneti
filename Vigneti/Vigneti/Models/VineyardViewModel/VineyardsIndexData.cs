using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vigneti.Models.VineyardViewModel
{
    public class VineyardsIndexData
    {
        public IEnumerable<Vineyard> Vineyards { get; set; }
        public IEnumerable<Vineyard> Vineyards2 { get; set; }
        public IEnumerable<Vineyard> Vineyards3 { get; set; }
        public IEnumerable<VineGrower> VineGrowers { get; set; }
        public IEnumerable<Wine> Wines { get; set; }
    }
}
