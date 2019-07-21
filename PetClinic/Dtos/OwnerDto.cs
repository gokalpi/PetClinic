using System.Collections.Generic;

namespace PetClinic.Dtos
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Telephone { get; set; }
        public ICollection<PetDto> Pets { get; set; } = new HashSet<PetDto>();
    }
}