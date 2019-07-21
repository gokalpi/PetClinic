using System;
using System.Collections.Generic;

namespace PetClinic.Dtos
{
    public class PetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Type { get; set; }

        public string Owner { get; set; }
        public ICollection<VisitDto> Visits { get; set; }
    }
}