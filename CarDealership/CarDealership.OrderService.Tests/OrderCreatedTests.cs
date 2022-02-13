using AutoMapper;
using CarDealership.Messages;
using CarDealership.OrderService.Consumers;
using CarDealership.OrderService.Data;
using CarDealership.OrderService.Tests.Fakes;
using MassTransit.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.OrderService.Tests
{
    [TestClass]
    public class OrderCreatedTests
    {
        OrderContext _ctx;
        IMapper _mapper;

        public OrderCreatedTests()
        {
            _ctx = FakeContextGenerator.GenerateFakeContext();
            _mapper = FakeAutomapperGenerator.GenerateFakeAutomapper();
        }

        [TestMethod]
        public async Task CheckOrderDbCreated()
        {
            var harness = new InMemoryTestHarness();
            var consumerHarness = harness.Consumer<OrderCreatedConsumer>(() => 
            {
                return new OrderCreatedConsumer(_ctx, _mapper);
            });

            await harness.Start();
            try
            {
                await harness.InputQueueSendEndpoint.Send<OrderCreated>(new OrderCreated()
                {
                    CarModelId = 2,
                    SelectedCarOptions = new System.Collections.Generic.List<int>() { 1, 2 },
                    Comment = "Test",
                    CustomerData = new CustomerData()
                    {
                        Email = "12",
                        FirstName = "23",
                        LastName = "45",
                        Phone = "343"
                    }
                });
            }
            finally
            {
                await harness.Stop();
            }
            var createdOrder = _ctx.CarOrders.FirstOrDefault();
            Assert.IsNotNull(createdOrder);


            Assert.IsTrue(createdOrder.CarModelId == 2);
            Assert.IsNotNull(createdOrder.Customer);
            Assert.IsTrue(createdOrder.CarOrderOptions.Count == 2);
        }
    }
}
