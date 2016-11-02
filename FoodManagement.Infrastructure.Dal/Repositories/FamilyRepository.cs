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
        DbContext _context;
        IMapper _mapper;
        public FamilyRepository(DbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
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
            return _mapper.Map<Core.Model.Family>(base.GetById(id));
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
