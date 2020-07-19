using System.Collections.Generic;

namespace API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductCatalogId { get; set; }
        public List<ProductCatalog> ProductCatalog { get; set; }

        public int StoreId { get; set; }

    }
}