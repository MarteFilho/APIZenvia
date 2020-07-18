using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> OrderItem { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public double Total { get; set; }
    }
}
