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
    public class ShoppingListRepository : GenericRepository<ShoppingListItem>, IShoppingListRepository
    {
        public ShoppingListRepository(IDataContext context) : base(context)
        {
            
        }

        public void Delete(Guid shoppingListItemId)
        {
            base.Delete(base.SelectById(shoppingListItemId));
        }
    }
}
