using FoodManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using AutoMapper;

namespace FoodManagement.Infrastructure.Dal
{
    public class ShoppingListRepository : GenericRepository<ShoppingListItem>, IRepository<Core.Model.ShoppingListItem>
    {
        IMapper _mapper;
        public ShoppingListRepository(IDataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public void Delete(Core.Model.ShoppingListItem entity)
        {
            Delete(_mapper.Map<ShoppingListItem>(entity));
        }

        public IEnumerable<Core.Model.ShoppingListItem> Select(Expression<Func<Core.Model.ShoppingListItem, bool>> filter = null, Func<IQueryable<Core.Model.ShoppingListItem>, IOrderedQueryable<Core.Model.ShoppingListItem>> orderBy = null, string includeProperties = "")
        {
            return base.Select(_mapper.Map<Expression<Func<ShoppingListItem, bool>>>(filter),
                _mapper.Map<Func<IQueryable<ShoppingListItem>, IOrderedQueryable<ShoppingListItem>>>(orderBy), 
                includeProperties).Select(sli => _mapper.Map<Core.Model.ShoppingListItem>(sli));
        }

        public new Core.Model.ShoppingListItem SelectById(Guid id, string includeProperties = "")
        {
            return _mapper.Map<Core.Model.ShoppingListItem>(base.SelectById(id, includeProperties));
        }

        public void Insert(Core.Model.ShoppingListItem entity)
        {
            base.Insert(_mapper.Map<ShoppingListItem>(entity));
        }

        public void Update(Core.Model.ShoppingListItem entity)
        {
            base.Update(_mapper.Map<ShoppingListItem>(entity));
        }
    }
}
