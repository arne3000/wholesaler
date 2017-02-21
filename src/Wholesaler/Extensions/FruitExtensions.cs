using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wholesaler.Models;

namespace Wholesaler.Extensions
{
    public static class FruitExtensions
    {
        public static decimal ConvertStockLevelForCases(this Fruit fruit)
        {
            return RateConverter(fruit.StockLevel, fruit.ConversionRateForCases);
        }

        public static decimal ConvertStockLevelForPallets(this Fruit fruit)
        {
            return RateConverter(fruit.StockLevel, fruit.ConversionRateForPallets);
        }


        private static decimal RateConverter(decimal units, decimal conversionRate)
        {
            if (units <= 0 || conversionRate <= 0)
            {
                return 0;
            }

            return units / conversionRate;
        }
    }
}
