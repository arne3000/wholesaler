using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wholesaler.DTOs
{
    public class FruitDTO
    {
        public string Name { get; set; }
        public decimal PalletCost { get; set; }
        public int UnitsPerCase { get; set; }
        public int CasesPerPallet { get; set; }
    }
}
