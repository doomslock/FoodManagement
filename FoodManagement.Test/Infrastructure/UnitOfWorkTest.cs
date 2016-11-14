using FoodManagement.Core;
using FoodManagement.Infrastructure.Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagement.Test.Infrastructure
{
    [TestClass]
    public class UnitOfWorkTest
    {
        [TestMethod]
        public void UnitOfWorkDisposeTest()
        {
            IDataContext context = new FMDbContext();
            IUnitOfWork unitOfWork = new UnitOfWork(null, context);

            // opening connection
            unitOfWork.BeginTransaction();
            unitOfWork.Commit();

            // calling dispose 1st time
            unitOfWork.Dispose();
            var isDisposed = (bool)GetInstanceField(typeof(UnitOfWork), unitOfWork, "_disposed");
            Assert.IsTrue(isDisposed);

            // calling dispose 2nd time, should not throw any excpetions
            unitOfWork.Dispose();
            context.Dispose();

            // calling dispose 3rd time, should not throw any excpetions
            context.Dispose();
            unitOfWork.Dispose();
        }

        [TestMethod]
        public void IDataContextDisposeTest()
        {
            IDataContext context = new FMDbContext();
            IUnitOfWork unitOfWork = new UnitOfWork(null, context);

            // opening connection
            unitOfWork.BeginTransaction();
            unitOfWork.Commit();

            // calling dispose 1st time
            context.Dispose();

            var isDisposed = (bool)GetInstanceField(typeof(FMDbContext), context, "_disposed");
            Assert.IsTrue(isDisposed);

            // calling dispose 2nd time, should not throw any excpetions
            unitOfWork.Dispose();
            context.Dispose();

            // calling dispose 3rd time, should not throw any excpetions
            unitOfWork.Dispose();
            context.Dispose();
        }

        private static object GetInstanceField(Type type, object instance, string fieldName)
        {
            const BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            var field = type.GetField(fieldName, bindFlags);
            return field != null ? field.GetValue(instance) : null;
        }

        public TestContext TestContext { get; set; }
    }
}
