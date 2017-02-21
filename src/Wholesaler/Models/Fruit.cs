using System.ComponentModel.DataAnnotations;

namespace Wholesaler.Models
{
    public class Fruit
    {
        [Key]
        public string Name { get; set; }
        public decimal UnitCost { get; set; }
        public int StockLevel { get; set; }
        public int ConversionRateForCases { get; set; }
        public int ConversionRateForPallets { get; set; }
    }
}
