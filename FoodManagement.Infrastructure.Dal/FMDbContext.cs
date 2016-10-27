using System;
using FoodManagement.Core;
using System.Data.Entity;

namespace FoodManagement.Infrastructure.Dal
{
    public class FMDbContext : DbContext
    {
        public FMDbContext() : base(@"Data Source=(localdb)\v11.0;Initial Catalog=FoodManagement;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
    }
}
