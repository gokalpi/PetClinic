using AutoMapper;
using PetClinic.Models;

namespace PetClinic.Dtos
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Owner, OwnerDto>().ReverseMap(); ;
            CreateMap<Pet, PetDto>().ReverseMap(); ;
            CreateMap<Specialty, SpecialtyDto>().ReverseMap(); ;
            CreateMap<Vet, VetDto>().ReverseMap(); ;
            CreateMap<Visit, VisitDto>().ReverseMap(); ;
        }
    }
}