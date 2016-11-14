using System;

namespace FoodManagement.Core
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();
        void SyncObjectState<TEntity>(TEntity entity) where TEntity : class, IDataEntity;
        void SyncObjectsStatePostCommit();
    }
}
