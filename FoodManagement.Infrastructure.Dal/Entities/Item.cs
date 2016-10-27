using System;
using System.ComponentModel.DataAnnotations;

namespace FoodManagement.Infrastructure.Dal
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
