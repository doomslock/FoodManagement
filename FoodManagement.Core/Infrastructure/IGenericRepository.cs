using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FoodManagement.Core
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity,bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        TEntity GetById(Guid id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
