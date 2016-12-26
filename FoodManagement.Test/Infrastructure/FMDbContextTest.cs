using FoodManagement.Core.Model;
using FoodManagement.Infrastructure.Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodManagement.Test.Infrastructure
{
    [TestClass]
    [Ignore]
    public class FMDbContextTest
    {
        FMDbContext context;
        [TestInitialize]
        //[Ignore]
        public void Initialize()
        {
            context = new FMDbContext();
        }

        [TestMethod]
        [Ignore]
        public void ClearAndFillDatabase()
        {
            FillDbWithTestData();
            Assert.IsNotNull(context.Set<Family>().First());
            Assert.IsNotNull(context.Set<Person>().First());
            Assert.IsNotNull(context.Set<Item>().First());
            Assert.IsNotNull(context.Set<Store>().First());
            Assert.IsNotNull(context.Set<ShoppingListItem>().First());
        }

        private void FillDbWithTestData()
        {
            context.Database.ExecuteSqlCommand("DELETE FROM people");
            context.Database.ExecuteSqlCommand("DELETE FROM shoppinglistItems");
            context.Database.ExecuteSqlCommand("DELETE FROM families");
            context.Database.ExecuteSqlCommand("DELETE FROM items");
            context.Database.ExecuteSqlCommand("DELETE FROM stores");

            var store = new Store() { Id = Guid.NewGuid(), Name = "Delhaize" };
            var item = new Item() { Id = Guid.NewGuid(), Name = "Mango", Description = "Tropical Fruit" };
            var family = new Family() { Name = "Van den Driessche", Id = Guid.NewGuid() };
            var sli = new ShoppingListItem() { Id = Guid.NewGuid(), Amount = 3, BuyAtStoreId = store.Id, ItemId = item.Id, FamilyId = family.Id };
            var user = new Person() { Id = Guid.NewGuid(), Name = "Jens", LastName = "Van den Driessche", Email = "vandendriesschejens@msn.com", Family = family };
            context.Set<Person>().Add(user);
            context.Set<Item>().Add(item);
            context.Set<Store>().Add(store);
            context.Set<ShoppingListItem>().Add(sli);
            context.SaveChanges();
        }
    }
}
