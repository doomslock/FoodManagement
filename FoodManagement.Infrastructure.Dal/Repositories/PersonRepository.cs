using FoodManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using AutoMapper;
using FoodManagement.Core.Model;

namespace FoodManagement.Infrastructure.Dal
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(IDataContext context) : base(context)
        {
        }
    }
}
