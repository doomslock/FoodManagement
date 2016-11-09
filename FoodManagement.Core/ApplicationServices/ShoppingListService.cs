using FoodManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodManagement.Core
{
    public class ShoppinglistService : IShoppinglistService
    {
        private IUnitOfWork _unitOfWork;

        public ShoppinglistService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public void AddItemToFamilyShoppinglist(Guid PersonId, ShoppinglistItem item)
        {
            var family = _unitOfWork.Repository<Family>().Get( f => f.FamilyMembers.First(fm => fm.Id == PersonId) != null).First();
            family.AddShoppinglistItem(item);
            _unitOfWork.Repository<Family>().Update(family);
            _unitOfWork.Save();
        }

        public IEnumerable<ShoppinglistItem> GetFamilyShoppinglist(Guid PersonId)
        {
            var person = _unitOfWork.Repository<Person>().GetById(PersonId);
            return _unitOfWork.Repository<Family>().GetById(person.FamilyId, "Shoppinglist, Shoppinglist.Item").Shoppinglist;
        }

        public void MarkAllShoppinglistItemsAsBought(Guid FamilyId)
        {
            var familie = _unitOfWork.Repository<Family>().GetById(FamilyId);
            familie.MarkAllItemsAsBought();
            _unitOfWork.Repository<Family>().Update(familie);
            _unitOfWork.Save();
        }

        public void MarkShoppinglistItemAsBought(Guid FamilyId, Guid ItemId)
        {
            var familie = _unitOfWork.Repository<Family>().GetById(FamilyId);
            familie.MarkItemAsBought(ItemId);
            _unitOfWork.Repository<Family>().Update(familie);
            _unitOfWork.Save();
        }
    }
}
