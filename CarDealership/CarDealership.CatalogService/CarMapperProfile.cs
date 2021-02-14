using AutoMapper;
using CarDealership.CatalogService.Data;
using CarDealership.CatalogService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.CatalogService
{
    public class CarMapperProfile: Profile
    {
        public CarMapperProfile()
        {
            CreateMap<CarOption, CarOptionDto>();
            CreateMap<CarOptionGroup, CarOptionGroupDto>();
            CreateMap<CarManufacturer, CarManufacturerDto>();
            CreateMap<CarModel, CarModelDto>();
            CreateMap<CarModel, CarModelFullDto>();
        }
    }
}
