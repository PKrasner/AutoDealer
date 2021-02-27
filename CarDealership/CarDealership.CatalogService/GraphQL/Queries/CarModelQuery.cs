using CarDealership.CatalogService.Data;
using CarDealership.CatalogService.GraphQL.GraphTypes;
using GraphQL.Language.AST;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.CatalogService.GraphQL.Queries
{
    public class CarModelQuery : ObjectGraphType
    {
        public CarModelQuery(CatalogContext catalogContext)
        {
            Field<ListGraphType<CarModelGraphType>>(
                "carModels",
                resolve: context =>
                {
                    var nodes = _fetchNodes(context.FieldAst);

                    IQueryable<CarModel> carModels = catalogContext.CarModels;

                    if (nodes.Contains("carManufacturer"))
                        carModels = carModels.Include(x => x.CarManufacturer);

                    if (nodes.Contains("carOptionGroups"))
                        carModels = carModels.Include(x => x.CarOptionGroups);

                    if (nodes.Contains("carOptions"))
                        carModels = carModels.Include("CarOptionGroups.CarOptions");

                    return carModels.ToList();
                });
        }

        private List<string> _fetchNodes(Field node)
        {
            if (node.SelectionSet == null || node.SelectionSet.Children == null ||  !node.SelectionSet.Children.Any()) return new List<string>();

            return node.SelectionSet.Children.OfType<Field>().SelectMany(x => _fetchNodes(x)).Concat(new List<string>() { node.Name }).ToList();
        }
    }
}
