using System;

namespace PetClinic.Models
{
    public class Visit : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public int VetId { get; set; }
        public int PetId { get; set; }

        public Vet AssignedVet { get; set; }
        public Pet Pet { get; set; }
    }
}