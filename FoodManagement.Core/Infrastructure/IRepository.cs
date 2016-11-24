using FoodManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FoodManagement.Core
{
    public interface IRepository<TEntity> where TEntity : class, IDataEntity
    {
        IEnumerable<TEntity> Select(Expression<Func<TEntity,bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        TEntity SelectById(Guid id, string includeProperties = "", Expression<Func<TEntity, bool>> filter = null);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
