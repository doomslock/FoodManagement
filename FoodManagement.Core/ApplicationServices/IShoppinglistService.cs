using FoodManagement.Core.DTO;
using System;
using System.Collections.Generic;

namespace FoodManagement.Core
{
    public interface IShoppingListService
    {
        
        IEnumerable<ShoppingListItem> GetFamilyShoppingList(Guid familyId);
        ShoppingListItem GetShoppingListItemDetailsById(Guid familyId, Guid id);
        ShoppingListItem GetShoppingListItemDetailsByName(Guid familyId, string name);
        void AddItemToFamilyShoppingList(Guid familyId, ShoppingListItem item);
        void MarkShoppingListItemAsBought(Guid familyId, Guid itemId);
        void MarkAllShoppingListItemsAsBought(Guid familyId);
        void AlterShoppingListItemDetails(Guid familyId, ShoppingListItem item);
        void RemoveShoppingListItemForFamily(Guid familyId, Guid shoppingListItemId);
    }
}
