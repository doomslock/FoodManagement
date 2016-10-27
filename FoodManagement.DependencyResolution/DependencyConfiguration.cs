using FoodManagement.Core;
using FoodManagement.Infrastructure.Dal;
using Ninject;

namespace FoodManagement.DependencyResolution
{
    public class DependencyConfiguration
    {
        private IKernel kernel;

        public DependencyConfiguration()
        {
            kernel = new StandardKernel();
            kernel.Bind<IGenericRepository<Family>>().To<GenericRepository<Family>>();
            kernel.Bind<IGenericRepository<Person>>().To<GenericRepository<Person>>();
            kernel.Bind<IGenericRepository<ShoppinglistItem>>().To<GenericRepository<ShoppinglistItem>>();
            kernel.Bind<IRepositoryFactory>().To<RepositoryFactory>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IShoppinglistService>().To<ShoppinglistService>();
        }

        public TService GetInstance<TService>()
        {
            return kernel.Get<TService>();
        }
    }
}
