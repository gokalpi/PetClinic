using System.Collections.Generic;

namespace PetClinic.Models
{
    public class Owner : Person
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Telephone { get; set; }

        public ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();
    }
}