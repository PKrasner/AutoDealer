using CarDealership.CatalogService.Controllers;
using CarDealership.CatalogService.Tests.Fakes;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server.Common;
using GraphQL.Server.Transports.AspNetCore.Common;
using GraphQL.Server;
using CarDealership.CatalogService.GraphQL.Queries;
using CarDealership.CatalogService.GraphQL.GraphTypes;
using CarDealership.CatalogService.GraphQL.Schemas;
using GraphQL.Tests;

namespace CarDealership.CatalogService.Tests
{
    [TestClass]
    public class GraphQLTests: QueryTestBase<CatalogSchema>
    {
        public GraphQLTests()
        {
            var collection = new ServiceCollection();

            var ctx = FakeContextGenerator.GenerateFakeContext();
            var mapper = FakeAutomapperGenerator.GenerateFakeAutomapper();

            collection.AddSingleton<Data.CatalogContext>(ctx);
            collection.AddScoped<CatalogSchema>();
            collection.AddScoped<CarModelQuery>();
            collection.AddScoped<CarModelGraphType>();
            collection.AddScoped<CarManufacturerGraphType>();
            collection.AddScoped<CarOptionGroupGraphType>();
            collection.AddScoped<CarOptionGraphType>();


            Services.Register<CarModelQuery>();
            Services.Register<CarManufacturerGraphType>();
            Services.Register<CarModelGraphType>();
            Services.Register<CarOptionGroupGraphType>();
            Services.Register<CarOptionGraphType>();

            Services.Singleton(new CatalogSchema(collection.BuildServiceProvider()));


        }

        [TestMethod]
        public void SimpleCarModelAttributeFetch()
        {
            var query = @"
                 {
                  carModels {
                    name
                  }
                }
            ";

            var expected =
                @"
{
""carModels"": [
      {
        ""name"": ""test1""
      },
      {
        ""name"": ""test2""
      }
    ]
  }
";

            AssertQuerySuccess(query, expected);
        }


        [TestMethod]
        public void LinkedOptionsObjectsFetch()
        {
            var query = @"
                {
  carModels {
    name
    carOptionGroups {
      name
      minOptions
      maxOptions
      carOptions {
        name
        description
        price
      }
    }
  }
}
            ";

            var expected =
                @"{
        ""carModels"": [
          {
            ""name"": ""test1"",
            ""carOptionGroups"": [
              {
                ""name"": ""TestGroup"",
                ""minOptions"": 0,
                ""maxOptions"": 1,
                ""carOptions"": [
                  {
                    ""name"": ""TestOption1"",
                    ""description"": null,
                    ""price"": 500
                  },
                  {
                    ""name"": ""TestOption2"",
                    ""description"": null,
                    ""price"": 200
                  }
                ]
              }
            ]
          },
          {
            ""name"": ""test2"",
            ""carOptionGroups"": []
          }
        ]
      
    }";

            AssertQuerySuccess(query, expected);
        }


        [TestMethod]
        public void FilterManufacturerId()
        {
            var query = @"
                {
  carModels (carManufacturerId: 1) {
    name
  }
}
            ";

            var expected =
                @"{
    ""carModels"": [
      {
                ""name"": ""test1""
      }
    ]
    }";

            AssertQuerySuccess(query, expected);
        }
    }
}
