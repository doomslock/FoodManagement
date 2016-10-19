﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagement.Core
{
    public interface IRepositoryFactory
    {
        IGenericRepository<TEntity> GetInstance<TEntity>() where TEntity : class;
    }
}
