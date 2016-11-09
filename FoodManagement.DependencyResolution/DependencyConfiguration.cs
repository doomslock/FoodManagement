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

            kernel.Bind<DbContext>().To<FMDbContext>();
            kernel.Bind<IRepository<Core.Model.Family>>().To<FamilyRepository>();
            kernel.Bind<IRepository<Core.Model.Person>>().To<PersonRepository>();
            kernel.Bind<IRepository<Core.Model.ShoppinglistItem>>().To<ShoppinglistRepository>();
            kernel.Bind<IRepositoryFactory>().To<RepositoryFactory>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IShoppinglistService>().To<ShoppinglistService>();
            kernel.Bind<IMapper>().ToConstant(
                new MapperConfiguration(c =>
                {
                    foreach (var profile in MapperProfiles())
                        c.AddProfile(profile);
                }).CreateMapper());
        }

        private IEnumerable<Profile> MapperProfiles()
        {
            List<Profile> profiles = new List<Profile>();

            profiles.Add(new newProfile());

            return profiles;
        }

        public TService GetInstance<TService>()
        {
            return kernel.Get<TService>();
        }

        internal class newProfile : Profile
        {
            protected override void Configure()
            {
                CreateMap<Core.Model.Family, Family>();
                CreateMap<Family, Core.Model.Family>();
                CreateMap<Core.Model.Person, Person>();
                CreateMap<Person, Core.Model.Person>();

                //CreateMap<Core.Model.ShoppinglistItem, ShoppinglistItem>().ForMember(dest => dest.Item.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Item.Description, opt => opt.MapFrom(src => src.Description));
                CreateMap<ShoppinglistItem, Core.Model.ShoppinglistItem>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Item.Name)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Item.Description)).ConstructUsing(x => new Core.Model.ShoppinglistItem(x.Id, x.Item.Name, x.Amount));
            }

        }

        //public class CustomResolver : ValueResolver<Source, int>
        //{
        //    protected override int ResolveCore(Source source)
        //    {
        //        return source.Value1 + source.Value2;
        //    }
        //}
    }
}
