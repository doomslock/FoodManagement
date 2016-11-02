using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FoodManagement.Core;
using System.Collections.Generic;
using System.Linq;
using FoodManagement.Infrastructure.Dal;
using System.Data.Entity;

namespace FoodManagement.Test
{
    [TestClass]
    public class ShoppinglistServiceTest
    {
        ShoppinglistService sls;
        Core.Model.Person currentUser;
        [TestInitialize]
        public void Initialize()
        {
            var uowMock = new Mock<IUnitOfWork>();
            var contextMock = new Mock<DbContext>();
            var repMock = new Mock<IRepository<Core.Model.Family>>(contextMock.Object) { CallBase = true };
            var dbSetMock = new Mock<DbSet<Core.Model.Family>>();
            List<Core.Model.Family> familyList = new List<Core.Model.Family>();
            List<Core.Model.Person> people = new List<Core.Model.Person>();
            var shoppinglist = new List<Core.Model.ShoppinglistItem>();
            shoppinglist.Add(new Core.Model.ShoppinglistItem(Guid.NewGuid(), "Ananas", 1));
            var familyId = Guid.NewGuid();
            currentUser = new Core.Model.Person(Guid.NewGuid(), familyId, "Jens", "Van den Driessche", "vandendriesschejens@msn.com");
            people.Add(currentUser);
            familyList.Add(new Core.Model.Family(familyId, "Van den Driessche", shoppinglist, people));

            dbSetMock.As<IQueryable<Core.Model.Family>>().Setup(m => m.Provider).Returns(familyList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Core.Model.Family>>().Setup(m => m.Expression).Returns(familyList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Core.Model.Family>>().Setup(m => m.ElementType).Returns(familyList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Core.Model.Family>>().Setup(m => m.GetEnumerator()).Returns(() => familyList.AsQueryable().GetEnumerator());
            dbSetMock.Setup(m => m.Attach(It.IsAny<Core.Model.Family>())).Callback((Core.Model.Family f) => { var a = familyList.First(fi => fi.Id == f.Id); a = f; });
            contextMock.Setup(c => c.Set<Core.Model.Family>()).Returns(dbSetMock.Object);
            repMock.Setup(m => m.Update(It.IsAny<Core.Model.Family>())).Callback((Core.Model.Family f) => {
                var a = familyList.First(fi => fi.Id == f.Id);
                a = f;
            });
            uowMock.Setup(m => m.Repository<Core.Model.Family>()).Returns(repMock.Object);
            
            sls = new ShoppinglistService(uowMock.Object);
        }

        [TestMethod]
        public void AddItemToFamilyShoppinglistTest()
        {
            var sli = new Core.Model.ShoppinglistItem(Guid.NewGuid(), "Kiwi", 5);
            sls.AddItemToFamilyShoppinglist(currentUser.Id, sli);
            var sl = sls.GetFamilyShoppinglist(currentUser.Id);
            Assert.IsNotNull(sl.FirstOrDefault(s => s.Id == sli.Id));
        }

        [TestMethod]
        public void MarkShoppinglistItemAsBought()
        {
            var sl = sls.GetFamilyShoppinglist(currentUser.Id).First();
            sls.MarkShoppinglistItemAsBought(currentUser.FamilyId, sl.Id);
            Assert.IsFalse(sls.GetFamilyShoppinglist(currentUser.Id).Any(sli => sli.Id == sl.Id));
        }
    }
}
