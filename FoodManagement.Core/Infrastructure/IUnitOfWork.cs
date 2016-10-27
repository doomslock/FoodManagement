using System.Data;

namespace FoodManagement.Core
{
    public interface IUnitOfWork
    {
        void Save();
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        void Commit();
        void RollBack();
    }
}
