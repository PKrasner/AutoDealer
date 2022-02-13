using System;
using System.Collections.Generic;

namespace CarDealership.Messages
{
    public class OrderCreated
    {
        
        public CustomerData CustomerData { get; set; }
        public List<int> SelectedCarOptions { get; set; }
        public string Comment { get; set; }
        public int CarModelId { get; set; }
    }

    public class CustomerData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }


}
