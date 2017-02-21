using System.Threading.Tasks;
using Wholesaler.Models;

namespace Wholesaler.Commands
{
    public class NewDeliveryCommand
    {
        private ApplicationDbContext Context;
        private int Pallets; 

        public NewDeliveryCommand(ApplicationDbContext context)
        {
            Context = context;
            Pallets = 0;
        }

        public NewDeliveryCommand AddPallets(int pallets)
        {
            Pallets = pallets;
            return this;
        }

        public async Task Execute(Fruit fruit)
        {
            var newfruit = fruit.ConversionRateForPallets * Pallets;
            fruit.StockLevel += newfruit;
            await Context.SaveChangesAsync();
        }
    }
}
