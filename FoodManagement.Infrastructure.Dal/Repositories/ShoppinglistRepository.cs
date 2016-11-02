using FoodManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using AutoMapper;

namespace FoodManagement.Infrastructure.Dal
{
    public class ShoppinglistRepository : GenericRepository<ShoppinglistItem>, IRepository<Core.Model.ShoppinglistItem>
    {
        DbContext _context;
        IMapper _mapper;
        public ShoppinglistRepository(DbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Delete(Core.Model.ShoppinglistItem entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Model.ShoppinglistItem> Get(Expression<Func<Core.Model.ShoppinglistItem, bool>> filter = null, Func<IQueryable<Core.Model.ShoppinglistItem>, IOrderedQueryable<Core.Model.ShoppinglistItem>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public new Core.Model.ShoppinglistItem GetById(Guid id)
        {
            return _mapper.Map<Core.Model.ShoppinglistItem>(base.GetById(id));
        }

        public void Insert(Core.Model.ShoppinglistItem entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Core.Model.ShoppinglistItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
