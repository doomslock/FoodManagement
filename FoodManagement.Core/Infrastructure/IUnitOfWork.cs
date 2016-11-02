using FoodManagement.Core.Model;
using System.Data;

namespace FoodManagement.Core
{
    public interface IUnitOfWork
    {
        void Save();
        IRepository<TEntity> Repository<TEntity>() where TEntity : class, IModelEntity;
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        void Commit();
        void RollBack();
    }
}
