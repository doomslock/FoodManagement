using FoodManagement.Core;
using FoodManagement.Core.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodManagement.Core.Model
{
    [Table("People")]
    public class Person : IDataEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid FamilyId { get; set; }
        public Family Family { get; set; }
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}
