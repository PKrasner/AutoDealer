using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealership.Messages;
using Microsoft.Extensions.Logging;
using AutoMapper;
using CarDealership.OrderService.Data;

namespace CarDealership.OrderService.Consumers
{
    public class OrderCreatedConsumer : IConsumer<OrderCreated>
    {
        OrderContext _orderContext;
        IMapper _mapper;

        public OrderCreatedConsumer(OrderContext orderContext, IMapper mapper)
        {
            _orderContext = orderContext;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<OrderCreated> context)
        {
            Console.WriteLine("order received" + context.Message.Comment);

            var newOrder = _mapper.Map<CarOrder>(context.Message);
            _orderContext.CarOrders.Add(newOrder);
            await _orderContext.SaveChangesAsync();

            Console.WriteLine("order saved" + context.Message.Comment);
        }
    }
}
