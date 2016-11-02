
namespace FoodManagement.Core
{
    public interface IDataMapperFactory
    {
        IDataMapper GetInstance<IModelEntity>();        
    }
}
