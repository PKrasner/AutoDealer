using CarDealership.CatalogService.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.CatalogService.Tests.Fakes
{
    public static class FakeContextGenerator
    {
        public static CatalogContext GenerateFakeContext()
        {
            var options = new DbContextOptionsBuilder<CatalogContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var ctx = new CatalogContext(options);

            ctx.CarModels.AddRange(new CarModel()
            {
                Id = 1,
                Name = "test1",
                Price = 1000,
                CarManufacturer = new CarManufacturer()
                {
                    Id = 1,
                    Name = "BMW"
                },
                CarOptionGroups = new List<CarOptionGroup>()
                 {
                     new CarOptionGroup()
                     {
                          Id = 1,
                           Name= "TestGroup",
                            CarModelId = 1,
                             MinOptions =0,
                             MaxOptions =1,
                              CarOptions = new List<CarOption>()
                              {
                                  new CarOption()
                                  {
                                       Id = 1,
                                        Name = "TestOption1",
                                         CarOptionGroupId = 1,
                                          Price = 500
                                  },
                                   new CarOption()
                                  {
                                       Id = 2,
                                        Name = "TestOption2",
                                         CarOptionGroupId = 1,
                                          Price = 200
                                  }
                              }
                     }
                 }

            }, new CarModel()
            {
                Name = "test2",
                Id = 2,
                Price = 2000,
                CarManufacturer = new CarManufacturer()
                {
                    Id = 2,
                    Name = "KIA"
                }
            });
            ctx.SaveChanges();

            return ctx;
        }
    }
}
