using Microsoft.EntityFrameworkCore;
using Bangazon_Financial_API.Models;

namespace Bangazon_Financial_API.Data
{
    //Class Name: BangazonWebContext
    //Author: Grant Regnier
    //Purpose of the class: The purpose of this class is to create a context in memory for our Controllers to interact with our Database.
    //Methods in Class: No Methods but DBSets of Customer, LineItem, Order, PaymentType, Product, ProductType
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
