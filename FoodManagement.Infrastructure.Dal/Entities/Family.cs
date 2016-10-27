using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodManagement.Infrastructure.Dal
{
    public class Family
    {
        [Key]
        Guid Id { get; set; }
        string Name { get; set; }
        public ICollection<ShoppinglistItem> Items { get; set; }
    }
}
