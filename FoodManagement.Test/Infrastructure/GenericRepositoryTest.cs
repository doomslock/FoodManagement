using FoodManagement.Infrastructure.Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace FoodManagement.Test.Infrastructure
{
    [TestClass]
    public class GenericRepositoryTest
    {
        private GenericRepository<ShoppinglistItem> _rep;

        [TestInitialize]
        public void Initialize()
        {
            var context = new Mock<FMDbContext>();
            var dbSet = new Mock<DbSet<ShoppinglistItem>>();
            List<ShoppinglistItem> sliList = new List<ShoppinglistItem>();
            dbSet.Setup(d => d.Add(It.IsAny<ShoppinglistItem>())).Callback((ShoppinglistItem sli) => sliList.Add(sli));
            context.Setup(c => c.Set<ShoppinglistItem>()).Returns(dbSet.Object);
            _rep = new GenericRepository<ShoppinglistItem>(context.Object);
        }

        [TestMethod]
        public void Insert()
        {
            
        }
    }
}
