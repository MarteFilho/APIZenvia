using System.Collections.Generic;

namespace API.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public int ProductCatalogId { get; set; }
        public ProductCatalog ProductCatalog { get; set; }
    }
}
