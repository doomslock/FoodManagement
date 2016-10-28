using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoodManagement.Core.Infrastructure;

namespace FoodManagement.Infrastructure.Dal
{
    [Table("ShoppinglistItems")]
    public class ShoppinglistItem : IDataEntity
    {
        [Key]
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public Guid FamilyId { get; set; }
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        public Guid BuyAtStoreId { get; set; }
        public Store BuyAtStore { get; set; }
    }
}
