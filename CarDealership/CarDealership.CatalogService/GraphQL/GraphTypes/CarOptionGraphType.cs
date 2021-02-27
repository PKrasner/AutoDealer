using CarDealership.CatalogService.Data;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.CatalogService.GraphQL.GraphTypes
{
    public class CarOptionGraphType : ObjectGraphType<CarOption>
    {
        public CarOptionGraphType()
        {
            Field(x => x.Id);
            Field(x => x.Name, nullable: true);
            Field(x => x.Price);
            Field(x => x.Description, nullable: true);
        }
    }
}
