using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FoodManagement.Core;
using System.Collections.Generic;
using System.Linq;

namespace FoodManagement.Test
{
    [TestClass]
    public class ShoppingListServiceTest
    {
        ShoppinglistService slService;
        Core.Model.Person currentUser;
        [TestInitialize]
        public void Initialize()
        {
            
            List<Core.Model.Family> familyList = new List<Core.Model.Family>();
            List<Core.Model.Person> people = new List<Core.Model.Person>();
            var shoppingList = new List<Core.Model.ShoppingListItem>();
            shoppingList.Add(new Core.Model.ShoppingListItem(Guid.NewGuid(), "Ananas", 1));
            var familyId = Guid.NewGuid();
            currentUser = new Core.Model.Person(Guid.Parse("D38A4709-4D0A-434B-905B-1ADACB7B015E"), familyId, "Jens", "Van den Driessche", "vandendriesschejens@msn.com");
            people.Add(currentUser);
            familyList.Add(new Core.Model.Family(familyId, "Van den Driessche", shoppingList, people));

            var uowMock = new Mock<IUnitOfWork>();
            var pRepMock = new Mock<IRepository<Core.Model.Person>>();
            pRepMock.Setup(m => m.SelectById(It.IsAny<Guid>(), "")).Returns((Guid g, string s) => g == currentUser.Id ? currentUser : null);
            uowMock.Setup(m => m.Repository<Core.Model.Person>()).Returns(pRepMock.Object);
            familyList.FirstOrDefault(f => f.Id == Guid.NewGuid());
            var fRepMock = new Mock<IRepository<Core.Model.Family>>();
            fRepMock.Setup(m => m.SelectById(It.IsAny<Guid>(), It.IsAny<string>())).Returns((Guid g, string s) => familyList.First(f => f.Id == g));
            fRepMock.Setup(m => m.Update(It.IsAny<Core.Model.Family>()));
            uowMock.Setup(m => m.Repository<Core.Model.Family>()).Returns(fRepMock.Object);
            uowMock.Setup(m => m.Save());
            slService = new ShoppinglistService(uowMock.Object);
        }

        [TestMethod]
        public void AddItemToFamilyShoppingListTest()
        {
            var sli = new Core.Model.ShoppingListItem(Guid.NewGuid(), "Kiwi", 5);
            slService.AddItemToFamilyShoppingList(currentUser.Id, sli);
            var sl = slService.GetFamilyShoppingList(currentUser.Id);
            Assert.IsNotNull(sl.FirstOrDefault(s => s.Id == sli.Id));
        }

        [TestMethod]
        public void MarkShoppingListItemAsBoughtTest()
        {
            var sl = slService.GetFamilyShoppingList(currentUser.Id).First();
            slService.MarkShoppingListItemAsBought(currentUser.Id, sl.Id);
            Assert.IsInstanceOfType(sl, typeof(Core.Model.ShoppingListItem));
            Assert.IsFalse(slService.GetFamilyShoppingList(currentUser.Id).Any(sli => sli.Id == sl.Id));
        }

        [TestMethod]
        public void MarkAllShoppingListItemsAsBoughtTest()
        {
            slService.MarkAllShoppingListItemsAsBought(currentUser.Id);
            Assert.AreEqual(0, slService.GetFamilyShoppingList(currentUser.Id).Count());
        }
    }
}
