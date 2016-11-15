﻿using AutoMapper;
using FoodManagement.Core;
using FoodManagement.Infrastructure.Dal;
using Ninject;
using System.Collections.Generic;
using System.Data.Entity;

namespace FoodManagement.DependencyResolution
{
    public class DependencyConfiguration
    {
        private IKernel kernel;

        public DependencyConfiguration()
        {
            kernel = new StandardKernel();

            kernel.Bind<IDataContext>().ToConstant(new FMDbContext());
            kernel.Bind<IRepository<Core.Model.Family>>().To<FamilyRepository>();
            kernel.Bind<IRepository<Core.Model.Person>>().To<PersonRepository>();
            kernel.Bind<IRepository<Core.Model.ShoppingListItem>>().To<ShoppingListRepository>();
            kernel.Bind<IRepositoryFactory>().To<RepositoryFactory>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IShoppingListService>().To<ShoppinglistService>();
            kernel.Bind<IMapper>().ToConstant(
                new MapperConfiguration(c =>
                {
                    foreach (var profile in MapperProfiles())
                        c.AddProfile(profile);
                }).CreateMapper());
        }

        public TService GetInstance<TService>()
        {
            return kernel.Get<TService>();
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
                CreateMap<Core.Model.Family, Family>();
                CreateMap<Family, Core.Model.Family>();
                CreateMap<Core.Model.Person, Person>();
                CreateMap<Person, Core.Model.Person>();

                CreateMap<Core.Model.ShoppingListItem, ShoppingListItem>();
                CreateMap<ShoppingListItem, Core.Model.ShoppingListItem>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Item.Name)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Item.Description)).ConstructUsing(x => new Core.Model.ShoppingListItem(x.Id, x.Item.Name, x.Amount));
            }

        }
    }
}
