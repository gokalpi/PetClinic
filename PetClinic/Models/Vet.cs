using System.Collections.Generic;

namespace PetClinic.Models
{
    public class Vet : Person
    {
        public ICollection<VetSpecialty> Specialties { get; set; } = new HashSet<VetSpecialty>();
        public ICollection<Visit> Visits { get; set; }
    }
}