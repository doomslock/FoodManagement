using AutoMapper;
using FoodManagement.Core;
using FoodManagement.Core.Model;
using System.Data.Entity;

namespace FoodManagement.Infrastructure.Dal
{
    public class RepositoryFactory : IRepositoryFactory
    {

        public RepositoryFactory()
        {
        }
        public IRepository<TEntity> GetInstance<TEntity>(IDataContext context) where TEntity: class, IDataEntity
        {
            switch (typeof(TEntity).ToString())
            {
                case "FoodManagement.Core.Model.Family":
                    return new FamilyRepository(context) as IRepository<TEntity>;
                case "FoodManagement.Core.Model.Person":
                    return new PersonRepository(context) as IRepository<TEntity>;
                case "FoodManagement.Core.Model.ShoppingListItem":
                    return new ShoppingListRepository(context) as IRepository<TEntity>;
                case "FoodManagement.Core.Model.Store":
                    return new StoreRepository(context) as IRepository<TEntity>;
                case "FoodManagement.Core.Model.Item":
                    return new ItemRepository(context) as IRepository<TEntity>;
                default:
                    throw new System.NotSupportedException($"The provided generic type argument {nameof(TEntity)} is of the type {typeof(TEntity)} which is an unsupported type in this method.");
            }
        }
    }
}
