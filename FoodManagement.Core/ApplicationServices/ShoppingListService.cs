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

        public void AddItemToFamilyShoppingList(Guid familyId, ShoppingListItem item)
        {
            //var family = _unitOfWork.Repository<Family>().SelectById(person.FamilyId, "ShoppingList, ShoppingList.Item");
            //family.AddShoppingListItem(item);
            //_unitOfWork.Repository<Family>().Update(family);
            (_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).Insert(item);
            _unitOfWork.Save();
        }

        public IEnumerable<ShoppingListItem> GetFamilyShoppingList(Guid familyId)
        {
            return _unitOfWork.Repository<Family>().SelectById(familyId, "Shoppinglist, Shoppinglist.Item, Shoppinglist.BuyAtStore").ShoppingList;
        }

        public void MarkAllShoppingListItemsAsBought(Guid familyId)
        {
            //var person = _unitOfWork.Repository<Person>().SelectById(familyId);
            //var familie = _unitOfWork.Repository<Family>().SelectById(person.FamilyId);
            //familie.MarkAllItemsAsBought();
            //_unitOfWork.Repository<Family>().Update(familie);
            var shoppingList = GetFamilyShoppingList(familyId);
            foreach (var item in shoppingList)
            {
                (_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).Delete(item);
            }
            _unitOfWork.Save();
        }

        public void MarkShoppingListItemAsBought(Guid familyId, Guid itemId)
        {
            //var person = _unitOfWork.Repository<Person>().SelectById(familyId);
            //var familie = _unitOfWork.Repository<Family>().SelectById(person.FamilyId);
            //familie.MarkItemAsBought(itemId);
            //_unitOfWork.Repository<Family>().Update(familie);
            var item = (_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).SelectById(itemId);
            (_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).Delete(item);
            _unitOfWork.Save();
        }

        public void AlterShoppingListItemDetails(Guid familyId, ShoppingListItem item)
        {
            (_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).Update(item);
            _unitOfWork.Save();
        }

        public ShoppingListItem GetShoppingListItemDetailsById(Guid id)
        {
            return (_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).SelectById(id, "Item, BuyAtStore");
        }

        public ShoppingListItem GetShoppingListItemDetailsByName(string name)
        {
            return (_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).Select(s => s.Item.Name == name, null, "Item, BuyAtStore").FirstOrDefault();
        }
    }
}
