

using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        public DbSet<Store> Store { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<ProductCatalog> ProductCatalog { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

    }
}
