using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodManagement.Infrastructure.Dal
{
    [Table("Stores")]
    public class Store
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
