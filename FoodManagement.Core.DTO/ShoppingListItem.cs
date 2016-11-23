using System;

namespace FoodManagement.Core.DTO
{
    public class ShoppingListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Store { get; set; }
        public string Description { get; set; }
        public bool Bought { get; set; }
    }
}
