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
        public FamilyRepository(IDataContext context) : base(context)
        {
        }
    }
}
