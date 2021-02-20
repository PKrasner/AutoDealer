using CarDealership.CatalogService.GraphQL.Queries;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CarDealership.CatalogService.GraphQL.Schemas
{
    public class CatalogSchema : Schema
    {
        public CatalogSchema(IServiceProvider resolver) :  base(resolver)
        {
            Query = resolver.GetService<CarModelQuery>();
        }
    }
}
