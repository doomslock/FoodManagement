using FoodManagement.Core.Model;
using System;
using System.Collections.Generic;

namespace FoodManagement.Core
{
    public interface IShoppingListService
    {
        void AddItemToFamilyShoppingList(Guid familyId, ShoppingListItem item);
        IEnumerable<ShoppingListItem> GetFamilyShoppingList(Guid familyId);
        void MarkShoppingListItemAsBought(Guid familyId, Guid itemId);
        void MarkAllShoppingListItemsAsBought(Guid familyId);
        void AlterShoppingListItemDetails(Guid familyId, ShoppingListItem item);
        ShoppingListItem GetShoppingListItemDetailsById(Guid id);
        ShoppingListItem GetShoppingListItemDetailsByName(string name);
    }
}
