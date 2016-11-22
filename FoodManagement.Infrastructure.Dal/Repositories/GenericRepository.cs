using FoodManagement.Core;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FoodManagement.Core.Model;

namespace FoodManagement.Infrastructure.Dal
{
    public abstract class GenericRepository<TDataEntity> where TDataEntity : class, IDataEntity
    {
        protected readonly DbContext _context;

        protected GenericRepository(IDataContext context)
        {
            _context = context as DbContext;
        }

        public virtual IEnumerable<TDataEntity> Select(
            Expression<Func<TDataEntity, bool>> filter = null,
            Func<IQueryable<TDataEntity>, IOrderedQueryable<TDataEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TDataEntity> query = _context.Set<TDataEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
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

        public virtual TDataEntity SelectById(Guid id, string includeProperties = "", Expression<Func<TDataEntity, bool>> filter = null)
        {
            Expression<Func<TDataEntity, bool>> exp;
            Expression<Func<TDataEntity, bool>> filter2 = (TDataEntity e) => e.Id == id;
            if (filter == null)
                exp = filter2;
            else
            {
                var body = Expression.AndAlso(filter?.Body, filter2.Body);
                exp = Expression.Lambda<Func<TDataEntity, bool>>(Expression.AndAlso(filter?.Body, filter2.Body), filter2.Parameters[0]);
            }
            return Select(exp, null, includeProperties).FirstOrDefault();
        }

        public virtual void Insert(TDataEntity entity)
        {
            entity.ObjectState = ObjectState.Added;
            _context.Set<TDataEntity>().Add(entity);
            //_context.Entry(entity).State = EntityState.Added;
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
            var entityInDb = _context.Set<TDataEntity>().Find(entityToUpdate.Id);
            entityToUpdate.ObjectState = ObjectState.Modified;
            if (entityInDb == null)
            {   
                _context.Set<TDataEntity>().Attach(entityToUpdate);
                _context.Entry(entityToUpdate).State = EntityState.Modified;
            }
            else
            {
                entityInDb.ObjectState = ObjectState.Modified;
                _context.Entry(entityInDb).CurrentValues.SetValues(entityToUpdate);
                _context.Entry(entityInDb).State = EntityState.Modified;
            }
        }
    }
}
