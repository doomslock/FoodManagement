using FoodManagement.Core;
using System;
using System.Data;

namespace FoodManagement.Infrastructure.Dal
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepositoryFactory _factory;

        public UnitOfWork(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return _factory.GetInstance<TEntity>();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
