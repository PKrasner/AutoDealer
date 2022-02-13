using AutoMapper;
using CarDealership.Messages;
using CarDealership.OrderService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.OrderService
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<OrderCreated, CarOrder>()
                 .ForMember(d => d.Customer, opt => opt.MapFrom(src => src.CustomerData))
                 .ForMember(d => d.CarOrderOptions, 
                 opt => opt.MapFrom(src => src.SelectedCarOptions.Select(x => new CarOrderOption()
                 {
                         CarOptionId = x
                 })
                 .ToList()));

            CreateMap<CustomerData, Customer>();
        }
    }
}
