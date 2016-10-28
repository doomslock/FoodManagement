
namespace FoodManagement.Core
{
    public interface IRepositoryFactory
    {
        IGenericRepository<TEntity> GetInstance<TEntity>() where TEntity : class;
    }
}
