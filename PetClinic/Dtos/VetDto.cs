using System.Collections.Generic;

namespace PetClinic.Dtos
{
    public class VetDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<SpecialtyDto> Specialties { get; set; } = new HashSet<SpecialtyDto>();
        public ICollection<VisitDto> Visits { get; set; }
    }
}