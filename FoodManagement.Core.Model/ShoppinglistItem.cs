using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoodManagement.Core;
using FoodManagement.Core.Model;

namespace FoodManagement.Core.Model
{
    [Table("ShoppinglistItems")]
    public class ShoppingListItem : IDataEntity
    {
        [Key]
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public Guid FamilyId { get; set; }
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        public Guid? BuyAtStoreId { get; set; }
        public Store BuyAtStore { get; set; }
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}
