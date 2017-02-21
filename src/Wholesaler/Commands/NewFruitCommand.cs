using System.Threading.Tasks;
using Wholesaler.Models;

namespace Wholesaler.Commands
{
    public class NewFruitCommand
    {
        private ApplicationDbContext Context;

        public NewFruitCommand(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task Execute(string fruitName, decimal palletCost, int unitsPerCase, int casesPerPallet)
        {
            var fruit = new Fruit()
            {
                Name = fruitName,
                StockLevel = 0,
                UnitCost = 0,
                ConversionRateForPallets = 0,
                ConversionRateForCases = unitsPerCase
            };

            fruit.ConversionRateForPallets = fruit.ConversionRateForCases * casesPerPallet;
            fruit.UnitCost = GetUnitCost(fruit.ConversionRateForPallets, palletCost);

            Context.Add(fruit);
            await Context.SaveChangesAsync();
        }

        private decimal GetUnitCost(int unitsInPallets, decimal palletCost)
        {
            if (unitsInPallets <= 0 || palletCost <= 0)
            {
                return 0;
            }

            return palletCost / unitsInPallets;
        }
    }
}
