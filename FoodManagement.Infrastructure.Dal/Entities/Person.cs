using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoodManagement.Core.Infrastructure;

namespace FoodManagement.Infrastructure.Dal
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
    }
}
