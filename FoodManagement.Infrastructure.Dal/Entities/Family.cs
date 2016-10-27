using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodManagement.Infrastructure.Dal
{
    [Table("Families")]
    public class Family
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
