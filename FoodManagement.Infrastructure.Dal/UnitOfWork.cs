using FoodManagement.Core;
using FoodManagement.Core.Model;
using System;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace FoodManagement.Infrastructure.Dal
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepositoryFactory _factory;
        private IDataContext _dataContext;
        private ObjectContext _objectContext;
        private DbTransaction _transaction;

        public UnitOfWork(IRepositoryFactory factory, IDataContext dataContext)
        {
            _factory = factory;
            _dataContext = dataContext;
        }
        
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class, IModelEntity
        {
            return _factory.GetInstance<TEntity>(_dataContext);
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            _objectContext = ((IObjectContextAdapter)_dataContext).ObjectContext;
            if (_objectContext.Connection.State != ConnectionState.Open)
            {
                _objectContext.Connection.Open();
            }

            _transaction = _objectContext.Connection.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void RollBack()
        {
            _transaction.Rollback();
            _dataContext.SyncObjectsStatePostCommit();
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }
    }
}
