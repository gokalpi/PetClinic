using System;
using System.Collections.Generic;

namespace PetClinic.Models
{
    public class Pet : BaseEntity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public PetType Type { get; set; }

        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

        public ICollection<Visit> Visits { get; set; } = new HashSet<Visit>();
    }
}