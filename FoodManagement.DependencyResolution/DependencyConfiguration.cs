using AutoMapper;
using FoodManagement.Core;
using FoodManagement.Infrastructure.Dal;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using FoodManagement.Core.Model;

namespace FoodManagement.DependencyResolution
{
    public class DependencyConfiguration
    {
        private IKernel _kernel;

        public StandardKernel Kernel { get { return (StandardKernel)_kernel; } }

        public DependencyConfiguration()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<IDataContext>().ToConstant(new FMDbContext());
            _kernel.Bind<IRepository<Family>>().To<FamilyRepository>();
            _kernel.Bind<IRepository<Person>>().To<PersonRepository>();
            _kernel.Bind<IRepository<ShoppingListItem>>().To<ShoppingListRepository>();
            _kernel.Bind<IRepositoryFactory>().To<RepositoryFactory>();
            _kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            _kernel.Bind<IShoppingListService>().To<ShoppinglistService>();
            _kernel.Bind<IMapper>().ToConstant(
                new MapperConfiguration(c =>
                {
                    foreach (var profile in MapperProfiles())
                        c.AddProfile(profile);
                }).CreateMapper());
        }

        public TService GetInstance<TService>()
        {
            return _kernel.Get<TService>();
        }

        private static IEnumerable<Profile> MapperProfiles()
        {
            List<Profile> profiles = new List<Profile>();

            profiles.Add(new ModelDataProfile());

            return profiles;
        }
        
        internal class ModelDataProfile : Profile
        {
            protected override void Configure()
            {
                
            }

            //public class FamilyResolver : IValueResolver<Core.Model.Family, Infrastructure.Dal.Family, List<Infrastructure.Dal.ShoppingListItem>>
            //{
            //    public List<Infrastructure.Dal.ShoppingListItem> Resolve(Core.Model.Family source, Infrastructure.Dal.Family destination, List<Infrastructure.Dal.ShoppingListItem> member, ResolutionContext context)
            //    {
            //        return List < Infrastructure.Dal.ShoppingListItem > Item() { Id = Guid.NewGuid(), Name = source.Name, Description = source.Description, ObjectState = source.ObjectState };
            //    }
            //}
        }
    }
}
