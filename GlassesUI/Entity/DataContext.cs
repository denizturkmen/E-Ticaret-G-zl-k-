using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GlassesUI.Entity
{
    public class DataContext : DbContext
    {
        public DataContext():base("GlassesConnnection")
        {
           // Database.SetInitializer(new DataInitializer());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
    }
}