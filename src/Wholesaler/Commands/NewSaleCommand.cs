using System.Threading.Tasks;
using Wholesaler.Models;

namespace Wholesaler.Commands
{
    public class NewSaleCommand
    {
        private ApplicationDbContext Context;
        private int Cases; 

        public NewSaleCommand(ApplicationDbContext context)
        {
            Context = context;
            Cases = 0;
        }

        public NewSaleCommand AddCases(int cases)
        {
            Cases = cases;
            return this;
        }

        public async Task Execute(Fruit fruit)
        {
            var newfruit = fruit.ConversionRateForCases * Cases;
            fruit.StockLevel -= newfruit;
            await Context.SaveChangesAsync();
        }
    }
}
