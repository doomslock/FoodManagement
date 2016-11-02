using AutoMapper;
using FoodManagement.Infrastructure.Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;

namespace FoodManagement.Test.Infrastructure
{
    [TestClass]
    public class ShoppinglistRepositoryTest
    {
        private ShoppinglistRepository _rep;

        [TestInitialize]
        public void Initialize()
        {
            var context = new Mock<FMDbContext>();
            var dbSet = new Mock<DbSet<ShoppinglistItem>>();
            var mapper = new Mock<IMapper>();
            List<ShoppinglistItem> sliList = new List<ShoppinglistItem>();
            dbSet.Setup(d => d.Add(It.IsAny<ShoppinglistItem>())).Callback((ShoppinglistItem sli) => sliList.Add(sli));
            context.Setup(c => c.Set<ShoppinglistItem>()).Returns(dbSet.Object);
            _rep = new ShoppinglistRepository(context.Object, mapper.Object);
        }

        [TestMethod]
        public void Insert()
        {
            
        }
    }
}
