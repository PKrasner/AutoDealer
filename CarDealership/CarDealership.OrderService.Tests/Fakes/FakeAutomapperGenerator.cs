using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.OrderService.Tests.Fakes
{
    public static class FakeAutomapperGenerator
    {
        public static IMapper GenerateFakeAutomapper()
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile<OrderMappingProfile>();
            });

            return config.CreateMapper();
        }
    }
}
