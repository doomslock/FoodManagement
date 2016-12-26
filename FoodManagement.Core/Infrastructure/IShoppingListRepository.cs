using FoodManagement.Core.Model;
using System;

namespace FoodManagement.Core
{
    public interface IShoppingListRepository : IRepository<ShoppingListItem>
    {
        void Delete(Guid shoppingListItemId);
    }
}
