using CarDealership.CatalogService.Data;
using CarDealership.CatalogService.GraphQL.GraphTypes;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.CatalogService.GraphQL.Queries
{
    public class CarModelQuery: ObjectGraphType
    {
        public CarModelQuery(CatalogContext catalogContext)
        {
            Field<ListGraphType<CarModelGraphType>>(
                "carModels",
                resolve: context =>
                {
                    return catalogContext.CarModels.ToList();
                });
        }
    }
}
