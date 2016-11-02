using FoodManagement.Core.Model;

namespace FoodManagement.Core
{
    public interface IDataMapper
    {
        IDataEntity Convert(IModelEntity modelEntity);
        IModelEntity Convert(IDataEntity dataEntity);
    }
}
