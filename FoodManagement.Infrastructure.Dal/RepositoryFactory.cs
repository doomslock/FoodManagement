using FoodManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagement.Infrastructure.Dal
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private IDataContext _context;
        private IUnitOfWork _unitOfWork;

        public RepositoryFactory(IDataContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public IGenericRepository<TEntity> GetInstance<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_context, _unitOfWork);
        }
    }
}
