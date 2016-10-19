using System.Data;

namespace FoodManagement.Core
{
    public interface IUnitOfWork
    {
        void Save();
        IGenericRepository<TEntity> Repository<TEntity>();//Implementation user service locator or abstract factory
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        void Commit();
        void RollBack();
    }
}
