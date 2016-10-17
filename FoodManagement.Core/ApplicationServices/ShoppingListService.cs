using FoodManagement.Core.Model;
using System;
using System.Collections.Generic;

namespace FoodManagement.Core
{
    public class ShoppingListService : IShoppinglistService
    {
        private IUnitOfWork _unitOfWork;

        public ShoppingListService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public void AddItemToFamilyShoppinglist(Guid PersonId, ShoppinglistItem item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShoppinglistItem> GetFamilyShoppinglist(Guid PersonId)
        {
            throw new NotImplementedException();
        }

        public void MarkAllShoppinglistItemsAsBought(Guid FamilyId)
        {
            throw new NotImplementedException();
        }

        public void MarkShoppinglistItemAsBought(Guid Item)
        {
            throw new NotImplementedException();
        }
    }
}
