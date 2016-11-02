using FoodManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FoodManagement.Core.Model;
using System.Linq.Expressions;

namespace FoodManagement.Infrastructure.Dal
{
    public class FamilyRepository : GenericRepository<Family>, IRepository<Core.Model.Family>
    {
        DbContext _context;
        IDataMapperFactory _mapperFactory;
        public FamilyRepository(DbContext context, IDataMapperFactory dataMapperFactory) : base(context, dataMapperFactory)
        {
            _context = context;
            _mapperFactory = dataMapperFactory;
        }

        public void Delete(Core.Model.Family entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Model.Family> Get(Expression<Func<Core.Model.Family, bool>> filter = null, Func<IQueryable<Core.Model.Family>, IOrderedQueryable<Core.Model.Family>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public new Core.Model.Family GetById(Guid id)
        {
            return _mapperFactory.GetInstance<Family>().Convert(base.GetById(id)) as Core.Model.Family;
        }

        public void Insert(Core.Model.Family entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Core.Model.Family entity)
        {
            throw new NotImplementedException();
        }
    }
}
