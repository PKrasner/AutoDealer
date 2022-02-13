using CarDealership.OrderService.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.OrderService.Tests.Fakes
{
    public static class FakeContextGenerator
    {
        public static OrderContext GenerateFakeContext()
        {
            var options = new DbContextOptionsBuilder<OrderContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var ctx = new OrderContext(options);

            ctx.SaveChanges();

            return ctx;
        }
    }
}
