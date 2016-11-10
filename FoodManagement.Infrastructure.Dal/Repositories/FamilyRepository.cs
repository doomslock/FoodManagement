using FoodManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using AutoMapper;

namespace FoodManagement.Infrastructure.Dal
{
    public class FamilyRepository : GenericRepository<Family>, IRepository<Core.Model.Family>
    {
        IMapper _mapper;
        public FamilyRepository(IDataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public void Delete(Core.Model.Family entity)
        {
            Delete(_mapper.Map<Family>(entity));
        }

        public IEnumerable<Core.Model.Family> Get(Expression<Func<Core.Model.Family, bool>> filter = null, Func<IQueryable<Core.Model.Family>, IOrderedQueryable<Core.Model.Family>> orderBy = null, string includeProperties = "")
        {
            Expression<Func<Family, bool>> filt = _mapper.Map<Expression<Func<Family, bool>>>(filter);
            Func<IQueryable<Family>, IOrderedQueryable<Family>> ord = _mapper.Map<Func<IQueryable<Family>, IOrderedQueryable<Family>>>(orderBy);
            return base.Get(filt, ord, includeProperties).Select(f => _mapper.Map<Core.Model.Family>(f));
        }

        public new Core.Model.Family GetById(Guid id, string includeProperties = "")
        {
            var a = base.GetById(id, includeProperties);
            return _mapper.Map<Core.Model.Family>(a);
        }

        public void Insert(Core.Model.Family entity)
        {
            base.Insert(_mapper.Map<Family>(entity));
        }

        public void Update(Core.Model.Family entity)
        {
            base.Update(_mapper.Map<Family>(entity));
        }
    }
}
