using AutoMapper;
using FoodManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodManagement.Core
{
    public class ShoppinglistService : IShoppingListService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public ShoppinglistService(IUnitOfWork uow, IMapper mapper)
        {

            _mapper = mapper;
            _unitOfWork = uow;
        }

        public IEnumerable<DTO.ShoppingListItem> GetFamilyShoppingList(Guid familyId)
        {
            return _unitOfWork.Repository<Family>().SelectById(familyId, "Shoppinglist, Shoppinglist.Item, Shoppinglist.BuyAtStore").ShoppingList.Select(sli => _mapper.Map<DTO.ShoppingListItem>(sli));
        }

        public void MarkAllShoppingListItemsAsBought(Guid familyId)
        {
            var shoppingList = GetFamilyShoppingList(familyId);
            foreach (var item in shoppingList)
            {
                (_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).Delete(_mapper.Map<ShoppingListItem>(item));
            }
            _unitOfWork.Save();
        }

        public void MarkShoppingListItemAsBought(Guid familyId, Guid itemId)
        {
            var item = (_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).SelectById(itemId);
            (_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).Delete(item);
            _unitOfWork.Save();
        }

        public void AddItemToFamilyShoppingList(Guid familyId, DTO.ShoppingListItem shopItem)
        {
            var mappedItem = MapShoppingItem(familyId, shopItem);
            mappedItem.Id = Guid.NewGuid();
            (_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).Insert(mappedItem);
            _unitOfWork.Save();
        }

        public void AlterShoppingListItemDetails(Guid familyId, DTO.ShoppingListItem shopItem)
        {
            (_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).Update(MapShoppingItem(familyId, shopItem));
            _unitOfWork.Save();
        }
        
        public DTO.ShoppingListItem GetShoppingListItemDetailsById(Guid id)
        {
            return _mapper.Map<DTO.ShoppingListItem>((_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).SelectById(id, "Item, BuyAtStore"));
        }

        public DTO.ShoppingListItem GetShoppingListItemDetailsByName(string name)
        {
            return _mapper.Map<DTO.ShoppingListItem>((_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).Select(s => s.Item.Name == name, null, "Item, BuyAtStore").FirstOrDefault());
        }

        private ShoppingListItem MapShoppingItem(Guid familyId, DTO.ShoppingListItem shopItem)
        {
            var store = _unitOfWork.Repository<Store>().Select(s => s.Name.Equals(shopItem.Store)).FirstOrDefault();
            if (store == null)
            {
                store = new Store() { Id = Guid.NewGuid(), Name = shopItem.Store };
                _unitOfWork.Repository<Store>().Insert(store);
            }
            var item = _unitOfWork.Repository<Item>().Select(s => s.Name.Equals(shopItem.Name)).FirstOrDefault();
            if (item == null)
            {
                item = new Item() { Id = Guid.NewGuid(), Name = shopItem.Name, Description = shopItem.Description };
                _unitOfWork.Repository<Item>().Insert(item);
            }
            var mappedItem = _mapper.Map<ShoppingListItem>(shopItem);
            mappedItem.BuyAtStoreId = store.Id;
            mappedItem.FamilyId = familyId;
            mappedItem.ItemId = item.Id;

            return mappedItem;
        }
    }
}
