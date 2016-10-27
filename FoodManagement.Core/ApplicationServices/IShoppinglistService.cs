using FoodManagement.Core.Model;
using System;
using System.Collections.Generic;

namespace FoodManagement.Core
{
    public interface IShoppinglistService
    {
        void AddItemToFamilyShoppinglist(Guid PersonId, ShoppinglistItem item);
        IEnumerable<ShoppinglistItem> GetFamilyShoppinglist(Guid PersonId);
        void MarkShoppinglistItemAsBought(Guid FamilyId, Guid ItemId);
        void MarkAllShoppinglistItemsAsBought(Guid FamilyId);
    }
}
