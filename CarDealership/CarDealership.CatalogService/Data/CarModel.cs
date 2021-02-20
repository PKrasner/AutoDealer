using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.CatalogService.Data
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InfoText { get; set; }
        public decimal Price { get; set; }

        public int CarManufacturerId { get; set; }

        [ForeignKey("CarManufacturerId")]
        public virtual CarManufacturer CarManufacturer { get; set; }
        public virtual IList<CarOptionGroup> CarOptionGroups { get; set; }
    }
}
