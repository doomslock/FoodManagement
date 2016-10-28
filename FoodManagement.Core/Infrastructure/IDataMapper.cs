using FoodManagement.Core.Model;

namespace FoodManagement.Core.Infrastructure
{
    public interface IDataMapper
    {
        IDataEntity Convert(IModelEntity modelEntity);
        IModelEntity Convert(IDataEntity dataEntity);
    }
}
