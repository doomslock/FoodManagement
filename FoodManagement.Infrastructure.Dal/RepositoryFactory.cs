using AutoMapper;
using FoodManagement.Core;
using FoodManagement.Core.Model;
using System.Data.Entity;

namespace FoodManagement.Infrastructure.Dal
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private DbContext _context;
        private IMapper _mapper;

        public RepositoryFactory(DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IRepository<TEntity> GetInstance<TEntity>() where TEntity: class, IModelEntity
        {
            switch (typeof(TEntity).ToString())
            {
                case "FoodManagement.Core.Model.Family":
                    return new FamilyRepository(_context, _mapper) as IRepository<TEntity>;
                case "FoodManagement.Core.Model.Person":
                    return new PersonRepository(_context, _mapper) as IRepository<TEntity>;
                case "FoodManagement.Core.Model.ShoppinglistItem":
                    return new ShoppinglistRepository(_context, _mapper) as IRepository<TEntity>;
                default:
                    throw new System.ArgumentException();
            }
        }
    }
}
