using System.Data;

namespace FoodManagement.Core
{
    public interface IUnitOfWork
    {
        void Save();
        IGenericRepository<TEntity> Repository<TEntity>();
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        void Commit();
        void RollBack();
    }
}
