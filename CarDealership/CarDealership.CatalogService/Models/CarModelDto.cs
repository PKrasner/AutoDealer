using CarDealership.CatalogService.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.CatalogService.Models
{
    public class CarModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public CarManufacturerDto CarManufacturer { get; set; }
        
    }

    public class CarModelFullDto: CarModelDto
    {
        public List<CarOptionGroupDto> CarOptionGroups { get; set; }
    }
}
