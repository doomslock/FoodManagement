using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FoodManagement.Core.Model
{
    public class Family : IModelEntity
    {
        private List<ShoppingListItem> _shoppingList;
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public IEnumerable<Person> FamilyMembers { get; }
        public IEnumerable<ShoppingListItem> ShoppingList { get { return _shoppingList; } }

        public ObjectState ObjectState { get; set; }

        public Family(Guid id, string name, ICollection<ShoppingListItem> shoppingList, ICollection<Person> familyMembers)
        {
            Id = id;
            Name = name;
            _shoppingList = shoppingList.ToList();
            FamilyMembers = familyMembers.ToList();
        }

        public void AddShoppingListItem(ShoppingListItem item)
        {
            _shoppingList.Add(item);
        }
        public void MarkItemAsBought(Guid id)
        {
            _shoppingList.Remove(_shoppingList.First(sli => sli.Id == id));
        }
        public void MarkAllItemsAsBought()
        {
            _shoppingList.RemoveAll(sli => sli.Id != null);
        }
    }
}
