using FoodManagement.Core.Model;
using System;
using System.Collections.Generic;

namespace FoodManagement.Core
{
    public interface IShoppingListService
    {
        void AddItemToFamilyShoppingList(Guid personId, ShoppingListItem item);
        IEnumerable<ShoppingListItem> GetFamilyShoppingList(Guid personId);
        void MarkShoppingListItemAsBought(Guid personId, Guid itemId);
        void MarkAllShoppingListItemsAsBought(Guid personId);
    }
}
