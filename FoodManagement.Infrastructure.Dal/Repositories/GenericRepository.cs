using FoodManagement.Core;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FoodManagement.Infrastructure.Dal
{
    public abstract class GenericRepository<TDataEntity> where TDataEntity : class, IDataEntity
    {
        private readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<TDataEntity> Get(
            Expression<Func<TDataEntity, bool>> filter = null,
            Func<IQueryable<TDataEntity>, IOrderedQueryable<TDataEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TDataEntity> query = _context.Set<TDataEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TDataEntity GetById(Guid id, string includeProperties = "")
        {
            return Get(e => e.Id == id, null, includeProperties).First();
        }

        public virtual void Insert(TDataEntity entity)
        {
            _context.Set<TDataEntity>().Add(entity);
        }

        public virtual void Delete(TDataEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _context.Set<TDataEntity>().Attach(entityToDelete);
            }
            _context.Set<TDataEntity>().Remove(entityToDelete);
        }

        public virtual void Update(TDataEntity entityToUpdate)
        {
            _context.Set<TDataEntity>().Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
