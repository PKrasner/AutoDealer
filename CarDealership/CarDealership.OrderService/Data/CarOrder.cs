using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.OrderService.Data
{
    public class CarOrder
    {
        public int Id { get; set; }
        public int CarModelId { get; set; }    
        public string Comment { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual IList<CarOrderOption> CarOrderOptions { get; set; }

    }
}
