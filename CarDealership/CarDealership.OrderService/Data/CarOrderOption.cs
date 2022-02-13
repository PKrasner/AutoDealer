using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.OrderService.Data
{
    public class CarOrderOption
    {
        public int id { get; set; }
        public virtual CarOrder CarOrder { get; set; }
        public int CarOptionId { get; set; }
    }
}
