using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ProductCatalog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public double Price { get; set; }
        public double PromotionPrice { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
    }
}
