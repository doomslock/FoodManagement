using FoodManagement.Core;
using System.Data.Entity;

namespace FoodManagement.Infrastructure.Dal
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private DbContext _context;

        public RepositoryFactory(DbContext context)
        {
            _context = context;
        }
        public IGenericRepository<TEntity> GetInstance<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_context);
        }
    }
}
