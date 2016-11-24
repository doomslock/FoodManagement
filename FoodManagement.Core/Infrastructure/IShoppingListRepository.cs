using FoodManagement.Core.Model;
using System;

namespace FoodManagement.Core
{
    public interface IShoppingListRepository : IRepository<ShoppingListItem>
    {
        //void Insert(Guid familyId, ShoppingListItem entity);
        //void Update(Guid familyId, ShoppingListItem entity);
        void Delete(Guid shoppingListItemId);
    }
}
