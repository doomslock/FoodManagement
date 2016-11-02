
using FoodManagement.Core.Model;

namespace FoodManagement.Core
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> GetInstance<TEntity>() where TEntity : class, IModelEntity;
    }
}
