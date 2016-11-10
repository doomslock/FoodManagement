using FoodManagement.Core.Model;

namespace FoodManagement.Core
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> GetInstance<TEntity>(IDataContext context) where TEntity : class, IModelEntity;
    }
}
