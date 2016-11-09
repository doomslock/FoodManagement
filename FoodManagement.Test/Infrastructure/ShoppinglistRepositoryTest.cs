using AutoMapper;
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
    public class ShoppinglistRepositoryTest
    {
        private ShoppinglistRepository _rep;
        List<Core.Model.ShoppinglistItem> sliList;

        [TestInitialize]
        public void Initialize()
        {
            var dependencyConfig = new DependencyConfiguration();
            var mapper = dependencyConfig.GetInstance<IMapper>();
            var sliQ = new ShoppinglistItem[] 
            {
                new ShoppinglistItem() { Id = Guid.NewGuid(), Amount = 4, Item = new Item() { Id= Guid.NewGuid(), Name="Aquarius", Description="Sport energy drink"}},
                new ShoppinglistItem() { Id = Guid.NewGuid(), Amount = 2, Item = new Item() { Id= Guid.NewGuid(), Name="Watermelon", Description="Big Fruit"}}
            }.AsQueryable();
            sliList = sliQ.Select(sli => mapper.Map<Core.Model.ShoppinglistItem>(sli)).ToList();
            var context = new Mock<FMDbContext>();
            var dbSet = new Mock<DbSet<ShoppinglistItem>>();
            dbSet.As<IQueryable<ShoppinglistItem>>().Setup(m => m.Provider).Returns(sliQ.Provider);
            dbSet.As<IQueryable<ShoppinglistItem>>().Setup(m => m.Expression).Returns(sliQ.Expression);
            dbSet.As<IQueryable<ShoppinglistItem>>().Setup(m => m.ElementType).Returns(sliQ.ElementType);
            dbSet.As<IQueryable<ShoppinglistItem>>().Setup(m => m.GetEnumerator()).Returns(sliQ.GetEnumerator());
            //dbSet.Setup(d => d.Add(It.IsAny<ShoppinglistItem>())).Callback((ShoppinglistItem sli) => sliList.Add(sli));
            context.Setup(c => c.Set<ShoppinglistItem>()).Returns(dbSet.Object);
            _rep = new ShoppinglistRepository(context.Object, mapper);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var sli = sliList.First();
            var returnsli = _rep.GetById(sli.Id);
            Assert.AreEqual(sli.Id, returnsli.Id);
        }

        [TestMethod]
        public void GetTest()
        {
            var returnslis = _rep.Get();
            Assert.AreEqual(2, returnslis.Count());
        }
    }
}
