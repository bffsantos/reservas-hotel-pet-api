using AutoMapper;
using ReservasHotelPetAPI.Models;
using ReservasHotelPetAPI.Models.Enums;

namespace ReservasHotelPetAPI.DTOs.Mappings
{
    public class ModelsToDTOMappingProfile : Profile
    {
        public ModelsToDTOMappingProfile()
        {
            CreateMap<Animal, AnimalDTO>().ReverseMap();

            CreateMap<Tutor, TutorDTO>().ReverseMap();
            
            CreateMap<Animal, AnimalDTOUpdateRequset>().ReverseMap();
            CreateMap<Animal, AnimalDTOUpdateResponse>().ReverseMap();

            CreateMap<Reserva, ReservaDTO>()
                .ForMember(dest => dest.AnimalNome, opt => opt.MapFrom(src => src.Animal.Nome))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<ReservaDTO, Reserva>()
                .ForMember(dest => dest.Animal, opt => opt.MapFrom(src => new Animal { Nome = src.AnimalNome }))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => Enum.Parse<TipoReserva>(src.Tipo.ToString())))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<StatusReserva>(src.Status.ToString())));
        }
    }
}