using System;

namespace FoodManagement.Core.Model
{
    public class ShoppinglistItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Store { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
