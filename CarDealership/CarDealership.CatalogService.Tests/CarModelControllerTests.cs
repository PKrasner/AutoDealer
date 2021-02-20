using CarDealership.CatalogService.Controllers;
using CarDealership.CatalogService.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task TestFetchCarModelList()
        {
            var response = await _carModelsController.Get();
            Assert.IsTrue(response.ToList().Count > 0);
        }

        [TestMethod]
        public async Task TestFetchCarModelById()
        {
            var response = await _carModelsController.GetById(1);

            Assert.IsTrue(response != null);
            Assert.IsTrue(response.CarOptionGroups.Count > 0);
            Assert.IsTrue(response.CarOptionGroups.SelectMany(x => x.CarOptions).Count() > 0);
        }
    }
}
