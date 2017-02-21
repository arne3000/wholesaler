using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wholesaler.Models;
using Wholesaler.Queries;
using Wholesaler.Commands;
using Wholesaler.Extensions;
using Wholesaler.DTOs;

namespace Wholesaler.Controllers
{
    [Route("api/[controller]")]
    public class FruitController : Controller
    {
        private ApplicationDbContext Context;
        public FruitController(ApplicationDbContext context)
        {
            Context = context;
        }

        [HttpGet("{fruitName}/stock")]
        public async Task<IActionResult> Stock(string fruitName)
        {
            var fruit = await new FindFruitByName(Context).ExecuteAsync(fruitName);

            return Ok(new
            {
                Units = fruit.StockLevel,
                Cases = fruit.ConvertStockLevelForCases(),
                Pallets = fruit.ConvertStockLevelForPallets()
            });
        }

        [HttpPost("{fruitName}/sale")]
        public async Task<IActionResult> Sale(string fruitName, int value)
        {
            var fruit = await new FindFruitByName(Context).ExecuteAsync(fruitName);
            await new NewSaleCommand(Context).AddCases(value).Execute(fruit);
            return Ok();
        }

        [HttpPost("{fruitName}/delivery")]
        public async Task<IActionResult> Delivery(string fruitName, int value)
        {
            var fruit = await new FindFruitByName(Context).ExecuteAsync(fruitName);
            await new NewDeliveryCommand(Context).AddPallets(value).Execute(fruit);
            return Ok();
        }

        [HttpPost("{fruitName}/return")]
        public async Task<IActionResult> Return(string fruitName, int value)
        {
            var fruit = await new FindFruitByName(Context).ExecuteAsync(fruitName);
            await new NewReturnCommand(Context).AddUnits(value).Execute(fruit);
            return Ok();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]FruitDTO fruit)
        {
            if (string.IsNullOrEmpty(fruit.Name))
            {
                return BadRequest();
            }

            await new NewFruitCommand(Context).Execute(fruit.Name, fruit.PalletCost, fruit.UnitsPerCase, fruit.CasesPerPallet);

            return Ok();
        }
    }
}
