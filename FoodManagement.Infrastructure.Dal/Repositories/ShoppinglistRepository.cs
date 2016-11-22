using FoodManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using AutoMapper;
using FoodManagement.Core.Model;

namespace FoodManagement.Infrastructure.Dal
{
    public class ShoppingListRepository : GenericRepository<ShoppingListItem>, IShoppingListRepository
    {
        IMapper _mapper;
        public ShoppingListRepository(IDataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        //public void Insert(Guid familyId, ShoppingListItem entity)
        //{
        //    var item = _context.Set<Item>().FirstOrDefault(s => s.Name == entity.Name);
        //    var store = _context.Set<Store>().FirstOrDefault(s => s.Name == entity.Store);
        //    var mappedEntity = _mapper.Map<ShoppingListItem, ShoppingListItem>(entity,
        //        opt =>
        //        {
        //            opt.AfterMap((src, dest) => dest.BuyAtStore = store);
        //            opt.AfterMap((src, dest) => dest.FamilyId = familyId);
        //        }); //TODO: should i include all mapping in a method?

        //    if (item != null)
        //        mappedEntity.Item = item;
        //    base.Insert(mappedEntity);

        //}

        //public void Update(Guid familyId, ShoppingListItem entity)
        //{
        //    var item = _context.Set<Item>().FirstOrDefault(s => s.Name == entity.Name);
        //    if (item == null)
        //    {
        //        var a = new Item() { Id = Guid.NewGuid(), Name = entity.Name, Description = entity.Description, ObjectState = ObjectState.Added };
        //        _context.Set<Item>().Add(a);
        //        item = a;
        //    }
        //    var store = _context.Set<Store>().FirstOrDefault(s => s.Name == entity.Store);
        //    var mappedEntity = _mapper.Map<ShoppingListItem, ShoppingListItem>(entity,
        //        opt =>
        //        {
        //            opt.AfterMap((src, dest) => dest.FamilyId = familyId);
        //        }); //TODO: should i include all mapping in a method?
        //    mappedEntity.BuyAtStoreId = store.Id;
        //    mappedEntity.ItemId = item.Id;

        //    base.Update(mappedEntity);
        //}
    }
}
