using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wholesaler.Models;

namespace Wholesaler.Queries
{
    public class FindFruitByName
    {
        ApplicationDbContext Context;

        public FindFruitByName(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<Fruit> ExecuteAsync(string name)
        {
            return await Context.Fruits.FindAsync(name);
        }
    }
}
