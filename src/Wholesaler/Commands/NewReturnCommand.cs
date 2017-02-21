using System.Threading.Tasks;
using Wholesaler.Models;

namespace Wholesaler.Commands
{
    public class NewReturnCommand
    {
        private ApplicationDbContext Context;
        private int Units; 

        public NewReturnCommand(ApplicationDbContext context)
        {
            Context = context;
            Units = 0;
        }

        public NewReturnCommand AddUnits(int units)
        {
            Units = units;
            return this;
        }

        public async Task Execute(Fruit fruit)
        {
            fruit.StockLevel += Units;
            await Context.SaveChangesAsync();
        }
    }
}
