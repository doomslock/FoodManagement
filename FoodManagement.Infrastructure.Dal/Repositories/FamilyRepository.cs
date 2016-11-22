using FoodManagement.Core;
using FoodManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;

namespace FoodManagement.Infrastructure.Dal
{
    public class FamilyRepository : GenericRepository<Family>, IFamilyRepository
    {
        IMapper _mapper;
        public FamilyRepository(IDataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
    }
}
