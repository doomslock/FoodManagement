﻿using FoodManagement.Core.Model;
using System;
using System.Data;

namespace FoodManagement.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        IRepository<TEntity> Repository<TEntity>() where TEntity : class, IDataEntity;
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        void Commit();
        void Rollback();
    }
}
