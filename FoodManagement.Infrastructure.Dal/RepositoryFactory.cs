using AutoMapper;
using FoodManagement.Core;
using FoodManagement.Core.Model;
using System.Data.Entity;

namespace FoodManagement.Infrastructure.Dal
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private IMapper _mapper;

        public RepositoryFactory(IMapper mapper)
        {
            _mapper = mapper;
        }
        public IRepository<TEntity> GetInstance<TEntity>(IDataContext context) where TEntity: class, IModelEntity
        {
            switch (typeof(TEntity).ToString())
            {
                case "FoodManagement.Core.Model.Family":
                    return new FamilyRepository(context, _mapper) as IRepository<TEntity>;
                case "FoodManagement.Core.Model.Person":
                    return new PersonRepository(context, _mapper) as IRepository<TEntity>;
                case "FoodManagement.Core.Model.ShoppinglistItem":
                    return new ShoppingListRepository(context, _mapper) as IRepository<TEntity>;
                default:
                    throw new System.NotSupportedException($"The provided generic type argument {nameof(TEntity)} is of the type {typeof(TEntity)} which is an unsupported type in this method.");
            }
        }
    }
}
