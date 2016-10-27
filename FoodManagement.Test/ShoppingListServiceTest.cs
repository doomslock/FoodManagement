using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FoodManagement.Core;
using FoodManagement.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace FoodManagement.Test
{
    [TestClass]
    public class ShoppinglistServiceTest
    {
        ShoppingListService sls;
        Person currentUser;
        [TestInitialize]
        public void Initialize()
        {
            var mock = new Mock<IUnitOfWork>();
            List<ShoppinglistItem> l = new List<ShoppinglistItem>();
            mock.Setup(m => m.Repository<ShoppinglistItem>()).Returns<IGenericRepository<ShoppinglistItem>>( r => 
            {
                var mockRep = new Mock<IGenericRepository<ShoppinglistItem>>();
                mockRep.Setup(u => u.GetById(It.IsAny<Guid>())).Returns((Guid d) => new ShoppinglistItem() { Id = d, Amount = 5, Name = "Champagne", Description = "Bubbly grape juice"});
                mockRep.Setup(u => u.Insert(It.IsAny<ShoppinglistItem>())).Callback((ShoppinglistItem s) => l.Add(s));
                return mockRep.Object;
            });
            currentUser = new Person(Guid.NewGuid()) { Name = "Jens", LastName = "Van den Driessche"};
            sls = new ShoppingListService(mock.Object);
        }

        [TestMethod]
        public void AddItemToFamilyShoppinglist()
        {
            var sli = new ShoppinglistItem() { Id = Guid.NewGuid(), Amount = 5, Name = "Kiwi" };
            sls.AddItemToFamilyShoppinglist(currentUser.Id, sli);
            var sl = sls.GetFamilyShoppinglist(currentUser.Id);
            Assert.IsNotNull(sl.FirstOrDefault(s => s.Id == sli.Id));
        }
    }
}
