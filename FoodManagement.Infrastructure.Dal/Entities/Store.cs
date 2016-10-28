using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoodManagement.Core.Infrastructure;

namespace FoodManagement.Infrastructure.Dal
{
    [Table("Stores")]
    public class Store : IDataEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
