using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoodManagement.Core;
using FoodManagement.Core.Model;

namespace FoodManagement.Core.Model
{
    [Table("Stores")]
    public class Store : IDataEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}
