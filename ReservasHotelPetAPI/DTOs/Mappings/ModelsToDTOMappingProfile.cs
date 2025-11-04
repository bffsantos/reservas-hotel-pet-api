using AutoMapper;
using ReservasHotelPetAPI.Models;

namespace ReservasHotelPetAPI.DTOs.Mappings
{
    public class ModelsToDTOMappingProfile : Profile
    {
        public ModelsToDTOMappingProfile()
        {
            CreateMap<Animal, AnimalDTO>().ReverseMap();
            CreateMap<Tutor, TutorDTO>().ReverseMap();
            CreateMap<Reserva, ReservaDTO>().ReverseMap();
            CreateMap<Animal, AnimalDTOUpdateRequset>().ReverseMap();
            CreateMap<Animal, AnimalDTOUpdateResponse>().ReverseMap();
        }
    }
}