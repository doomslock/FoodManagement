﻿using FoodManagement.Core;
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

        public virtual TDataEntity SelectById(Guid id, string includeProperties = "")
        {
            return Select(e => e.Id == id, null, includeProperties).First();
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
