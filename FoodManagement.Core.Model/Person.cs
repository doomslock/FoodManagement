using System;

namespace FoodManagement.Core.Model
{
    public class Person : IModelEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid FamilyId { get; private set; }

        public ObjectState ObjectState { get; set; }

        public Person(Guid id, Guid familyId, string name, string lastName, string email)
        {
            Id = id;
            FamilyId = familyId;
            Name = name;
            LastName = lastName;
            Email = email;
        }
    }
}
