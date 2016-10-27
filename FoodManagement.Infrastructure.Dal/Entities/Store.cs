using System;
using System.ComponentModel.DataAnnotations;

namespace FoodManagement.Infrastructure.Dal
{
    public class Store
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
