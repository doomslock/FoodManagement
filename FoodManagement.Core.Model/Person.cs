using System;

namespace FoodManagement.Core.Model
{
    public class Person
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Person(Guid id)
        {
            Id = id;
        }
    }
}
