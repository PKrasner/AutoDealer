using CarDealership.CatalogService.Data;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.CatalogService.GraphQL.GraphTypes
{
    public class CarOptionGroupGraphType : ObjectGraphType<CarOptionGroup>
    {
        public CarOptionGroupGraphType()
        {
            Field(x => x.Id);
            Field(x => x.Name, nullable: true);
            Field(x => x.MinOptions);
            Field(x => x.MaxOptions);

            Field<ListGraphType<CarOptionGraphType>, IList<CarOption>>("carOptions")
                .Resolve(ctx => ctx.Source.CarOptions);
        }
    }
}
