using FoodManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using AutoMapper;

namespace FoodManagement.Infrastructure.Dal
{
    public class PersonRepository : GenericRepository<Person>, IRepository<Core.Model.Person>
    {
        IMapper _mapper;
        public PersonRepository(IDataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public void Delete(Core.Model.Person entity)
        {
            Delete(_mapper.Map<Person>(entity));
        }

        public IEnumerable<Core.Model.Person> Get(Expression<Func<Core.Model.Person, bool>> filter = null, Func<IQueryable<Core.Model.Person>, IOrderedQueryable<Core.Model.Person>> orderBy = null, string includeProperties = "")
        {
            Expression<Func<Person, bool>> filt = _mapper.Map<Expression<Func<Person, bool>>>(filter);
            Func<IQueryable<Person>, IOrderedQueryable<Person>> ord = _mapper.Map<Func<IQueryable<Person>, IOrderedQueryable<Person>>>(orderBy);
            return base.Get(filt, ord, includeProperties).Select(f => _mapper.Map<Core.Model.Person>(f));
        }

        public new Core.Model.Person GetById(Guid id, string includeProperties = "")
        {
            return _mapper.Map<Core.Model.Person>(base.GetById(id, includeProperties));
        }

        public void Insert(Core.Model.Person entity)
        {
            base.Insert(_mapper.Map<Person>(entity));
        }

        public void Update(Core.Model.Person entity)
        {
            base.Update(_mapper.Map<Person>(entity));
        }
    }
}
