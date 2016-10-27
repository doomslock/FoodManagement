using FoodManagement.Core.Model;
using System;
using System.Collections.Generic;

namespace FoodManagement.Core
{
    public interface IShoppinglistService
    {
        void AddItemToFamilyShoppinglist(Guid PersonId, ShoppinglistItem item);
        IEnumerable<ShoppinglistItem> GetFamilyShoppinglist(Guid PersonId);
        void MarkShoppinglistItemAsBought(Guid Item);
        void MarkAllShoppinglistItemsAsBought(Guid FamilyId);
    }
}
