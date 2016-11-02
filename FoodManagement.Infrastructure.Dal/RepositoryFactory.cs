using FoodManagement.Core;
using FoodManagement.Core.Model;
using System.Data.Entity;

namespace FoodManagement.Infrastructure.Dal
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private DbContext _context;
        private IDataMapperFactory _mapperFactory;

        public RepositoryFactory(DbContext context, IDataMapperFactory dataMapperFactory)
        {
            _context = context;
            _mapperFactory = dataMapperFactory;
        }
        public IRepository<TEntity> GetInstance<TEntity>() where TEntity: class, IModelEntity
        {
            switch (typeof(TEntity).ToString())
            {
                case "Core.Model.Family":
                    return new FamilyRepository(_context, _mapperFactory) as IRepository<TEntity>;
                case "Core.Model.Person":
                    return new PersonRepository(_context, _mapperFactory) as IRepository<TEntity>;
                case "Core.Model.ShoppinglistItem":
                    return new ShoppinglistRepository(_context, _mapperFactory) as IRepository<TEntity>;
                default:
                    throw new System.ArgumentException();
            }
        }
    }
}
