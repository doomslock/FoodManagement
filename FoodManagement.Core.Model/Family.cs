using System;
using System.Collections.Generic;

namespace FoodManagement.Core.Model
{
    public class Family
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public IEnumerable<Person> FamilyMembers { get; set; }
        public IEnumerable<ShoppinglistItem> ShoppingList { get; set; }
    }
}
