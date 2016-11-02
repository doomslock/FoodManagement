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
    public class ShoppinglistRepository : GenericRepository<ShoppinglistItem>, IRepository<Core.Model.ShoppinglistItem>
    {
        DbContext _context;
        IDataMapperFactory _mapperFactory;
        public ShoppinglistRepository(DbContext context, IDataMapperFactory dataMapperFactory) : base(context, dataMapperFactory)
        {
            _context = context;
            _mapperFactory = dataMapperFactory;
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
            return _mapperFactory.GetInstance<ShoppinglistItem>().Convert(base.GetById(id)) as Core.Model.ShoppinglistItem;
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
