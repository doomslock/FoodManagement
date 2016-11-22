using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoodManagement.Core;
using System.Collections.Generic;
using FoodManagement.Core.Model;

namespace FoodManagement.Core.Model
{
    [Table("Families")]
    public class Family : IDataEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Person> FamilyMembers { get; set; }
        public ICollection<ShoppingListItem> ShoppingList { get; set; }
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}
