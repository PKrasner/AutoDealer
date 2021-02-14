using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.CatalogService.Tests.Fakes
{
    public static class FakeAutomapperGenerator
    {
        public static IMapper GenerateFakeAutomapper()
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile<CarMapperProfile>();
            });

            return config.CreateMapper();
        }
    }
}
