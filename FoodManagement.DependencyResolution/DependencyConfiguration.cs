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
            kernel.Bind<IRepository<Core.Model.Family>>().To<FamilyRepository>();
            kernel.Bind<IRepository<Core.Model.Person>>().To<PersonRepository>();
            kernel.Bind<IRepository<Core.Model.ShoppinglistItem>>().To<ShoppinglistRepository>();
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
