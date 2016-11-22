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
        IMapper _mapper;
        public PersonRepository(IDataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
    }
}
