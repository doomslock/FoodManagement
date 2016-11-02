using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoodManagement.Core;

namespace FoodManagement.Infrastructure.Dal
{
    [Table("Families")]
    public class Family : IDataEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
