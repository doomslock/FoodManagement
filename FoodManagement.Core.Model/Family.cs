using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodManagement.Core.Model
{
    public class Family
    {
        private List<ShoppinglistItem> _shoppinglist;
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public IEnumerable<Person> FamilyMembers { get; }
        public IEnumerable<ShoppinglistItem> Shoppinglist { get { return _shoppinglist; } }
        public Family(Guid id, string name, List<ShoppinglistItem> shoppinglist, List<Person> familyMembers)
        {
            Id = id;
            Name = name;
            _shoppinglist = shoppinglist;
            FamilyMembers = familyMembers;
        }

        public void AddShoppinglistItem(ShoppinglistItem item)
        {
            _shoppinglist.Add(item);
        }
        public void MarkItemAsBought(Guid Id)
        {
            _shoppinglist.Remove(_shoppinglist.First(sli => sli.Id == Id));
        }
        public void MarkAllItemsAsBought()
        {
            _shoppinglist.RemoveAll(sli => sli.Id != null);
        }
    }
}
