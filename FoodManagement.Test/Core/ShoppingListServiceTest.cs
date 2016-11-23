using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FoodManagement.Core;
using System.Collections.Generic;
using System.Linq;
using FoodManagement.Core.Model;
using FoodManagement.DependencyResolution;
using AutoMapper;
using System.Linq.Expressions;

namespace FoodManagement.Test
{
    [TestClass]
    public class ShoppingListServiceTest
    {
        ShoppinglistService slService;
        Person currentUser;
        List<Family> familyList = new List<Family>();
        List<Person> people = new List<Person>();
        List<Item> items = new List<Item>();
        List<Store> stores = new List<Store>();
        List<ShoppingListItem> shoppingList = new List<ShoppingListItem>();

        [TestInitialize]
        public void Initialize()
        {
            shoppingList.Add(new ShoppingListItem() { Id = Guid.NewGuid(), Item = new Item() { Id = Guid.NewGuid(), Name = "Ananas" }, Amount = 1 });
            var familyId = Guid.NewGuid();
            currentUser = new Person() { Id = Guid.Parse("D38A4709-4D0A-434B-905B-1ADACB7B015E"), FamilyId = familyId, Name = "Jens", LastName = "Van den Driessche", Email = "vandendriesschejens@msn.com" };
            people.Add(currentUser);
            familyList.Add(new Family() { Id = familyId, Name = "Van den Driessche", ShoppingList = shoppingList, FamilyMembers = people });

            var uowMock = new Mock<IUnitOfWork>();
            //var pRepMock = new Mock<IRepository<Person>>();
            //pRepMock.Setup(m => m.SelectById(It.IsAny<Guid>(), "", null)).Returns((Guid g, string s) => g == currentUser.Id ? currentUser : null);
            //uowMock.Setup(m => m.Repository<Person>()).Returns(pRepMock.Object);
            //familyList.FirstOrDefault(f => f.Id == Guid.NewGuid());
            var fRepMock = new Mock<IRepository<Family>>();
            fRepMock.Setup(m => m.SelectById(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<Expression<Func<Family, bool>>>())).Returns((Guid g, string s, Expression<Func<Family, bool>> filter) => familyList.First(f => f.Id == g));
            fRepMock.Setup(m => m.SelectById(It.IsAny<Guid>(), null,null)).Returns((Guid g) => familyList.First(f => f.Id == g));
            fRepMock.Setup(m => m.Select(It.IsAny<Expression<Func<Family, bool>>>(), It.IsAny<Func<IQueryable<Family>, IOrderedQueryable<Family>>>(), It.IsAny<string>())).Returns((Expression<Func<Family, bool>> filter,
            Func<IQueryable<Family>, IOrderedQueryable<Family>> orderBy, string includeProperties) =>
            {
                var its = familyList.AsQueryable();
                if (filter != null)
                {
                    its = its.Where(filter);
                }
                if (orderBy != null)
                {
                    return orderBy(its).ToList();
                }
                else
                {
                    return its.ToList();
                }
            });
            //fRepMock.Setup(m => m.Update(It.IsAny<Family>()));
            //uowMock.Setup(m => m.Repository<Family>()).Returns(fRepMock.Object);
            var sliRepMock = new Mock<IShoppingListRepository>();
            sliRepMock.Setup(m => m.Insert(It.IsAny<ShoppingListItem>())).Callback((ShoppingListItem sli) =>
            {
                sli.Item = items.FirstOrDefault(i => i.Id == sli.ItemId);
                sli.BuyAtStore = stores.FirstOrDefault(s => s.Id == sli.BuyAtStoreId);
                shoppingList.Add(sli);
            });
            sliRepMock.Setup(m => m.Update(It.IsAny<ShoppingListItem>())).Callback((ShoppingListItem sli) =>
            {
                sli.Item = items.FirstOrDefault(i => i.Id == sli.ItemId);
                sli.BuyAtStore = stores.FirstOrDefault(s => s.Id == sli.BuyAtStoreId);
                shoppingList.Remove(shoppingList.FirstOrDefault(s => s.Id == sli.Id));
                shoppingList.Add(sli);
            });
            sliRepMock.Setup(m => m.SelectById(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<Expression<Func<ShoppingListItem, bool>>>())).Returns((Guid g, string s, Expression<Func<ShoppingListItem, bool>> filter) => shoppingList.First(f => f.Id == g));
            sliRepMock.Setup(m => m.Select(It.IsAny<Expression<Func<ShoppingListItem, bool>>>(), It.IsAny<Func<IQueryable<ShoppingListItem>, IOrderedQueryable<ShoppingListItem>>>(), It.IsAny<string>())).Returns((Expression<Func<ShoppingListItem, bool>> filter,
            Func<IQueryable<ShoppingListItem>, IOrderedQueryable<ShoppingListItem>> orderBy, string includeProperties) =>
            {
                var its = shoppingList.AsQueryable();
                if (filter != null)
                {
                    its = its.Where(filter);
                }
                if (orderBy != null)
                {
                    return orderBy(its).ToList();
                }
                else
                {
                    return its.ToList();
                }
            });

            sliRepMock.Setup(m => m.Delete(It.IsAny<ShoppingListItem>())).Callback((ShoppingListItem sli) => shoppingList.Remove(shoppingList.Where(s=> s.Id == sli.Id).FirstOrDefault()));
            var iRepMock = new Mock<IItemRepository>();
            iRepMock.Setup(m => m.Insert(It.IsAny<Item>())).Callback((Item i) => items.Add(i));
            iRepMock.Setup(m => m.Select(It.IsAny<Expression<Func<Item, bool>>>(), It.IsAny<Func<IQueryable<Item>, IOrderedQueryable<Item>>>(), It.IsAny<string>())).Returns((Expression<Func<Item, bool>> filter,
            Func<IQueryable<Item>, IOrderedQueryable<Item>> orderBy, string includeProperties) =>
                {
                    var its = items.AsQueryable();
                    if (filter != null)
                    {
                        its = its.Where(filter);
                    }
                    if (orderBy != null)
                    {
                        return orderBy(its).ToList();
                    }
                    else
                    {
                        return its.ToList();
                    }
                });
            var sRepMock = new Mock<IStoreRepository>();
            sRepMock.Setup(m => m.Insert(It.IsAny<Store>())).Callback((Store s) => stores.Add(s));
            sRepMock.Setup(m => m.Select(It.IsAny<Expression<Func<Store, bool>>>(), It.IsAny<Func<IQueryable<Store>, IOrderedQueryable<Store>>>(), It.IsAny<string>())).Returns((Expression<Func<Store, bool>> filter,
            Func<IQueryable<Store>, IOrderedQueryable<Store>> orderBy, string includeProperties) =>
            {
                var its = stores.AsQueryable();
                if (filter != null)
                {
                    its = its.Where(filter);
                }
                if (orderBy != null)
                {
                    return orderBy(its).ToList();
                }
                else
                {
                    return its.ToList();
                }
            });
            uowMock.Setup(m => m.Repository<Store>()).Returns(sRepMock.Object);
            uowMock.Setup(m => m.Repository<Item>()).Returns(iRepMock.Object);
            uowMock.Setup(m => m.Repository<ShoppingListItem>()).Returns(sliRepMock.Object);
            uowMock.Setup(m => m.Repository<Family>()).Returns(fRepMock.Object);
            uowMock.Setup(m => m.Save());
            slService = new ShoppinglistService(uowMock.Object, new DependencyConfiguration().GetInstance<IMapper>());
        }

        [TestMethod]
        public void AddItemToFamilyShoppingListTest()
        {
            var sli = new Core.DTO.ShoppingListItem() { Name = "Kiwi", Amount = 5 };
            slService.AddItemToFamilyShoppingList(currentUser.Id, sli);
            Assert.IsNotNull(shoppingList.FirstOrDefault(s => s.Item.Name == sli.Name));
        }

        [TestMethod]
        public void MarkShoppingListItemAsBoughtTest()
        {
            var sl = slService.GetFamilyShoppingList(currentUser.FamilyId).First();
            slService.MarkShoppingListItemAsBought(currentUser.FamilyId, sl.Id);
            Assert.IsInstanceOfType(sl, typeof(Core.DTO.ShoppingListItem));
            Assert.IsFalse(slService.GetFamilyShoppingList(currentUser.FamilyId).Any(sli => sli.Id == sl.Id));
        }

        [TestMethod]
        public void MarkAllShoppingListItemsAsBoughtTest()
        {
            slService.MarkAllShoppingListItemsAsBought(currentUser.FamilyId);
            Assert.AreEqual(0, slService.GetFamilyShoppingList(currentUser.FamilyId).Count());
        }

        [TestMethod]
        public void AlterShoppingListItemDetailsTest()
        {
            var slItem = shoppingList.First();
            var sli = new DependencyConfiguration().GetInstance<IMapper>().Map<Core.DTO.ShoppingListItem>(slItem);
            sli.Amount++;
            slService.AlterShoppingListItemDetails(currentUser.FamilyId, sli);
            Assert.AreEqual(sli.Amount, shoppingList.First(s => s.Id == slItem.Id).Amount);
        }

        [TestMethod]
        public void GetShoppingListItemDetailsById()
        {
            var id = shoppingList.First().Id;
            var returnId = slService.GetShoppingListItemDetailsById(id).Id;
            Assert.AreEqual(id, returnId);
        }

        [TestMethod]
        public void GetShoppingListItemDetailsByName()
        {
            var sli = shoppingList.First();
            var returnSli = slService.GetShoppingListItemDetailsByName(sli.Item.Name);
            Assert.AreEqual(sli.Item.Name, returnSli.Name);
        }
    }
}
