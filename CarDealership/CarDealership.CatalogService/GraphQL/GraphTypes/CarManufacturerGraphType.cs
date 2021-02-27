using CarDealership.CatalogService.Data;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.CatalogService.GraphQL.GraphTypes
{
    public class CarManufacturerGraphType : ObjectGraphType<CarManufacturer>
    {
        public CarManufacturerGraphType()
        {
            Field(x => x.Id);
            Field(x => x.Name, nullable: true);
        }
    }
}
