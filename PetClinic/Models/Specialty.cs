using System.Collections.Generic;

namespace PetClinic.Models
{
    public class Specialty : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<VetSpecialty> VetSpecialties { get; set; }
    }
}