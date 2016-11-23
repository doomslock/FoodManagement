using AutoMapper;
using FoodManagement.Core.Model;
using FoodManagement.DependencyResolution;
using FoodManagement.Infrastructure.Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FoodManagement.Test.Infrastructure
{
    [TestClass]
    public class ShoppingListRepositoryTest
    {
        private ShoppingListRepository _rep;
        List<ShoppingListItem> sliList;

        [TestInitialize]
        public void Initialize()
        {
            var dependencyConfig = new DependencyConfiguration();
            var mapper = dependencyConfig.GetInstance<IMapper>();
            var sliQ = new ShoppingListItem[] 
            {
                new ShoppingListItem() { Id = Guid.NewGuid(), Amount = 4, Item = new Item() { Id= Guid.NewGuid(), Name="Aquarius", Description="Sport energy drink"}},
                new ShoppingListItem() { Id = Guid.NewGuid(), Amount = 2, Item = new Item() { Id= Guid.NewGuid(), Name="Watermelon", Description="Big Fruit"}}
            }.AsQueryable();
            sliList = sliQ.Select(sli => mapper.Map<ShoppingListItem>(sli)).ToList();
            var context = new Mock<FMDbContext>();
            var dbSet = new Mock<DbSet<ShoppingListItem>>();
            dbSet.As<IQueryable<ShoppingListItem>>().Setup(m => m.Provider).Returns(sliQ.Provider);
            dbSet.As<IQueryable<ShoppingListItem>>().Setup(m => m.Expression).Returns(sliQ.Expression);
            dbSet.As<IQueryable<ShoppingListItem>>().Setup(m => m.ElementType).Returns(sliQ.ElementType);
            dbSet.As<IQueryable<ShoppingListItem>>().Setup(m => m.GetEnumerator()).Returns(sliQ.GetEnumerator());
            //dbSet.Setup(d => d.Add(It.IsAny<ShoppinglistItem>())).Callback((ShoppinglistItem sli) => sliList.Add(sli));
            context.Setup(c => c.Set<ShoppingListItem>()).Returns(dbSet.Object);
            _rep = new ShoppingListRepository(context.Object);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var sli = sliList.First();
            var returnsli = _rep.SelectById(sli.Id);
            Assert.AreEqual(sli.Id, returnsli.Id);
        }

        [TestMethod]
        public void GetTest()
        {
            var returnslis = _rep.Select();
            Assert.AreEqual(2, returnslis.Count());
        }
    }
}
