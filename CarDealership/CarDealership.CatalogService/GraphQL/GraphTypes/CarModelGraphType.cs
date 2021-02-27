using CarDealership.CatalogService.Data;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.CatalogService.GraphQL.GraphTypes
{
    public class CarModelGraphType : ObjectGraphType<CarModel>
    {
        public CarModelGraphType()
        {
            Field(x => x.Id);
            Field(x => x.Name, nullable: true);
            Field(x => x.InfoText, nullable: true);
            Field(x => x.Price);
            Field(x => x.CarManufacturerId);
            Field<CarManufacturerGraphType, CarManufacturer>("carManufacturer").Resolve(x => x.Source.CarManufacturer);


            Field<ListGraphType<CarOptionGroupGraphType>, IList<CarOptionGroup>>("carOptionGroups").Resolve(
           ctx =>
           {
               return ctx.Source.CarOptionGroups;
           });
        }
    }
}
