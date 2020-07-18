using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ProductCatalogId { get; set; }
        public List<ProductCatalog> ProductCatalog { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
    }
}
