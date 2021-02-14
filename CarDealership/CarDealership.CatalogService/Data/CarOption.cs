using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.CatalogService.Data
{
    public class CarOption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int CarOptionGroupId { get; set; }

        public virtual CarOptionGroup CarOptionGroup { get; set; }
    }
}
