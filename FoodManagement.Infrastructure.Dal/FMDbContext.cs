using System;
using FoodManagement.Core;
using System.Data.Entity;

namespace FoodManagement.Infrastructure.Dal
{
    class FMDbContext : DbContext
    {
        public FMDbContext() : base(@"Data Source=.\SQLEXPRESS;Initial Catalog=FoodManagement;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<ShoppinglistItem> ShoppinglistItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
