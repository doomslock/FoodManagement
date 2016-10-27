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
            kernel.Bind<IGenericRepository<Core.Model.Family>>().To<GenericRepository<Core.Model.Family>>();
            kernel.Bind<IGenericRepository<Core.Model.Person>>().To<GenericRepository<Core.Model.Person>>();
            kernel.Bind<IGenericRepository<Core.Model.ShoppinglistItem>>().To<GenericRepository<Core.Model.ShoppinglistItem>>();
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
