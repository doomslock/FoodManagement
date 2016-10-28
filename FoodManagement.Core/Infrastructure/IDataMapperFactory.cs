using FoodManagement.Core.Model;
namespace FoodManagement.Core.Infrastructure
{
    public interface IDataMapperFactory
    {
        IDataMapper GetInstance();        
    }
}
