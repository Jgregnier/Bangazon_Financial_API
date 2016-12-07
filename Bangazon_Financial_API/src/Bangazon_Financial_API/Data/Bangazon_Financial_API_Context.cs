using Microsoft.EntityFrameworkCore;
using Bangazon_Financial_API.Models;

namespace Bangazon_Financial_API.Data
{
    public class BangazonWebContext : DbContext
    {
        public BangazonWebContext(DbContextOptions<BangazonWebContext> options)
            : base(options)
        { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<LineItem> LineItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<SubProductType> SubProductType { get; set; }
    }
}
