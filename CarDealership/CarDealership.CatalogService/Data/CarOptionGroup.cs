using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.CatalogService.Data
{
    public class CarOptionGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinOptions { get; set; }
        public int MaxOptions { get; set; }
        public int CarModelId { get; set; }

        public virtual CarModel CarModel { get; set; }

        public virtual IList<CarOption> CarOptions { get; set; }

    }
}
