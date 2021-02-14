using AutoMapper;
using CarDealership.CatalogService.Controllers;
using CarDealership.CatalogService.Data;
using CarDealership.CatalogService.Tests.Fakes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace CarDealership.CatalogService.Tests
{
    [TestClass]
    public class CarModelControllerTests
    {
        private CarModelsController _carModelsController;
        public CarModelControllerTests()
        {
            var ctx = FakeContextGenerator.GenerateFakeContext();
            var mapper = FakeAutomapperGenerator.GenerateFakeAutomapper();
            _carModelsController = new CarModelsController(ctx, mapper);

        }

        [TestMethod]
        public void TestFetchCarModelList()
        {
            var result = _carModelsController.Get();
            Assert.IsTrue(result.ToList().Count > 0);
        }

        [TestMethod]
        public void TestFetchCarModelById()
        {
            var result = _carModelsController.GetById(1);

            Assert.IsTrue(result != null);
            Assert.IsTrue(result.CarOptionGroups.Count > 0);
            Assert.IsTrue(result.CarOptionGroups.SelectMany(x => x.CarOptions).Count() > 0);
        }
    }
}
