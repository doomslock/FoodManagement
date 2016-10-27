﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FoodManagement.Infrastructure.Dal
{
    public class Person
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
