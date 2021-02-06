using CarDealership.CatalogService.Controllers;
using CarDealership.CatalogService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace CarDealership.CatalogService.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var options = new DbContextOptionsBuilder<CatalogContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var ctx = new CatalogContext(options);

            ctx.CarModels.AddRange(new CarModel() { Id =1, Name = "test1", Price = 1000 }, new CarModel() { Name = "test2", Id =2, Price = 2000 });
            ctx.SaveChanges();
            var tt = new Mock<ILogger<WeatherForecastController>>();
            var weatherForecastController = new WeatherForecastController(ctx, tt.Object);
            var result = weatherForecastController.Get();
            Assert.IsTrue(result.ToList().Count > 0);
        }
    }
}
