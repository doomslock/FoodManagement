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
    public class PersonRepository : GenericRepository<Person>, IRepository<Core.Model.Person>
    {
        DbContext _context;
        IDataMapperFactory _mapperFactory;
        public PersonRepository(DbContext context, IDataMapperFactory dataMapperFactory) : base(context, dataMapperFactory)
        {
            _context = context;
            _mapperFactory = dataMapperFactory;
        }

        public void Delete(Core.Model.Person entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Model.Person> Get(Expression<Func<Core.Model.Person, bool>> filter = null, Func<IQueryable<Core.Model.Person>, IOrderedQueryable<Core.Model.Person>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public new Core.Model.Person GetById(Guid id)
        {
            return _mapperFactory.GetInstance<Person>().Convert(base.GetById(id)) as Core.Model.Person;
        }

        public void Insert(Core.Model.Person entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Core.Model.Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
