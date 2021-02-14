using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.CatalogService.Models
{
    public class CarOptionGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinOptions { get; set; }
        public int MaxOptions { get; set; }

        public List<CarOptionDto> CarOptions { get; set; }

    }
}
