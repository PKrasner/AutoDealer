using CarDealership.CatalogService.GraphQL.GraphTypes;
using CarDealership.CatalogService.GraphQL.Queries;
using CarDealership.CatalogService.GraphQL.Schemas;
using GraphQL.Tests;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.CatalogService.Tests
{
    public class CatalogTestBase : QueryTestBase<CatalogSchema>
    {
        protected IServiceProvider _provider;
        public CatalogTestBase(IServiceProvider provider)
        {
            _provider = provider;

            Services.Register<CarModelQuery>();
            Services.Register<CarManufacturerGraphType>();
            Services.Register<CarModelGraphType>();

            Services.Singleton(new CatalogSchema(provider));
        }
    }

    
}
