namespace FoodManagement.Core
{
    public interface IDataContext
    {
        int SaveChanges();
        void SyncObjectState<TEntity>(TEntity entity) where TEntity : class, IDataEntity;
        void SyncObjectsStatePostCommit();
    }
}
