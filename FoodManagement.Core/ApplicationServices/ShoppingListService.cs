using FoodManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodManagement.Core
{
    public class ShoppinglistService : IShoppingListService
    {
        private IUnitOfWork _unitOfWork;

        public ShoppinglistService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public void AddItemToFamilyShoppingList(Guid personId, ShoppingListItem item)
        {
            var person = _unitOfWork.Repository<Person>().SelectById(personId, "");
            var family = _unitOfWork.Repository<Family>().SelectById(person.FamilyId, "Shoppinglist, Shoppinglist.Item");
            family.AddShoppingListItem(item);
            _unitOfWork.Repository<Family>().Update(family);
            _unitOfWork.Save();
        }

        public IEnumerable<ShoppingListItem> GetFamilyShoppingList(Guid personId)
        {
            var person = _unitOfWork.Repository<Person>().SelectById(personId);
            return _unitOfWork.Repository<Family>().SelectById(person.FamilyId, "Shoppinglist, Shoppinglist.Item").ShoppingList;
        }

        public void MarkAllShoppingListItemsAsBought(Guid personId)
        {
            var person = _unitOfWork.Repository<Person>().SelectById(personId);
            var familie = _unitOfWork.Repository<Family>().SelectById(person.FamilyId);
            familie.MarkAllItemsAsBought();
            _unitOfWork.Repository<Family>().Update(familie);
            _unitOfWork.Save();
        }

        public void MarkShoppingListItemAsBought(Guid personId, Guid itemId)
        {
            var person = _unitOfWork.Repository<Person>().SelectById(personId);
            var familie = _unitOfWork.Repository<Family>().SelectById(person.FamilyId);
            familie.MarkItemAsBought(itemId);
            _unitOfWork.Repository<Family>().Update(familie);
            _unitOfWork.Save();
        }
    }
}
