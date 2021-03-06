﻿using AutoMapper;
using FoodManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodManagement.Core
{
    public class ShoppingListService : IShoppingListService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public ShoppingListService(IUnitOfWork uow, IMapper mapper)
        {

            _mapper = mapper;
            _unitOfWork = uow;
        }

        public IEnumerable<DTO.ShoppingListItem> GetFamilyShoppingList(Guid familyId)
        {
            return _unitOfWork.Repository<Family>().FindById(familyId, "Shoppinglist, Shoppinglist.Item, Shoppinglist.BuyAtStore").ShoppingList.Select(sli => _mapper.Map<DTO.ShoppingListItem>(sli));
        }

        public DTO.ShoppingListItem GetShoppingListItemDetailsById(Guid familyId, Guid itemId)
        {
            return _mapper.Map<DTO.ShoppingListItem>((_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).Find(sli => sli.Id == itemId && sli.FamilyId == familyId, null,"Item, BuyAtStore").FirstOrDefault());
        }

        public DTO.ShoppingListItem GetShoppingListItemDetailsByName(Guid familyId, string name)
        {
            return _mapper.Map<DTO.ShoppingListItem>((_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).Find(s => s.Item.Name == name && s.FamilyId == familyId, null, "Item, BuyAtStore").FirstOrDefault());
        }

        public void MarkAllShoppingListItemsAsBought(Guid familyId)
        {
            var shoppingList = GetFamilyShoppingList(familyId).ToList();
            foreach (var item in shoppingList)
            {
                (_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).Delete(item.Id);
            }
            _unitOfWork.Save();
        }

        public void MarkShoppingListItemAsBought(Guid familyId, Guid itemId)
        {
            var item = (_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).FindById(itemId);
            (_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).Delete(item);
            _unitOfWork.Save();
        }

        public void AddItemToFamilyShoppingList(Guid familyId, DTO.ShoppingListItem item)
        {
            var mappedItem = MapShoppingItem(familyId, item);
            mappedItem.Id = Guid.NewGuid();
            (_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).Insert(mappedItem);
            _unitOfWork.Save();
        }

        public void AlterShoppingListItemDetails(Guid familyId, DTO.ShoppingListItem item)
        {
            //TODO: Check if shopItem is in family shopping list
            (_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).Update(MapShoppingItem(familyId, item));
            _unitOfWork.Save();
        }

        public void RemoveShoppingListItemForFamily(Guid familyId, Guid shoppingListItemId)
        {
            if (GetShoppingListItemDetailsById(familyId, shoppingListItemId) == null)
                throw new ArgumentException($"The provided {nameof(shoppingListItemId)} is not in the family shopping list.");
            (_unitOfWork.Repository<ShoppingListItem>() as IShoppingListRepository).Delete(shoppingListItemId);
            _unitOfWork.Save();
        }

        private ShoppingListItem MapShoppingItem(Guid familyId, DTO.ShoppingListItem shopItem)
        {
            var mappedItem = _mapper.Map<ShoppingListItem>(shopItem);
            var store = _unitOfWork.Repository<Store>().Find(s => s.Name.Equals(shopItem.Store)).FirstOrDefault();
            if (store == null && !string.IsNullOrWhiteSpace(shopItem.Store))
            {
                store = new Store() { Id = Guid.NewGuid(), Name = shopItem.Store };
                _unitOfWork.Repository<Store>().Insert(store);
                mappedItem.BuyAtStoreId = store.Id;
                mappedItem.BuyAtStore = store;
            }
            var item = _unitOfWork.Repository<Item>().Find(s => s.Name.Equals(shopItem.Name)).FirstOrDefault();
            if (item == null)
            {
                if (string.IsNullOrWhiteSpace(shopItem.Name))
                    throw new ArgumentException("A value must be provided for the name of the item");
                item = new Item() { Id = Guid.NewGuid(), Name = shopItem.Name, Description = shopItem.Description };
                _unitOfWork.Repository<Item>().Insert(item);
            }
            mappedItem.FamilyId = familyId;
            mappedItem.ItemId = item.Id;
            mappedItem.Item = item;

            return mappedItem;
        }

        public IEnumerable<string> GetShoppingListItemNames(string searchTerm)
        {
            return _unitOfWork.Repository<Item>().Find(i => i.Name.Contains(searchTerm)).Select(i => i.Name);
        }

        public string GetDescriptionsForItemName(string v)
        {
            return _unitOfWork.Repository<Item>().Find(i => i.Name.Equals(v)).FirstOrDefault()?.Description;
        }
    }
}
