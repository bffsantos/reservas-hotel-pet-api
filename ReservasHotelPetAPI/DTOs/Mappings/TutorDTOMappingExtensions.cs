using ReservasHotelPetAPI.Models;

namespace ReservasHotelPetAPI.DTOs.Mappings
{
    public static class TutorDTOMappingExtensions
    {
        public static TutorDTO ToTutorDTO(this Tutor tutor)
        {
            if (tutor is null)
                return null;

            return new TutorDTO
            {
                Id = tutor.Id,
                Nome = tutor.Nome,
                Idade = tutor.Idade,
                Sexo = tutor.Sexo,
                DataNascimento = tutor.DataNascimento,
                Cpf = tutor.Cpf,
                Endereco = tutor.Endereco,
                Telefone = tutor.Telefone,
                Email = tutor.Email
            };
        }

        public static Tutor ToTutor(this TutorDTO tutorDto)
        {
            if (tutorDto is null)
                return null;

            return new Tutor
            {
                Id = tutorDto.Id,
                Nome = tutorDto.Nome,
                Idade = tutorDto.Idade,
                Sexo = tutorDto.Sexo,
                DataNascimento = tutorDto.DataNascimento,
                Cpf = tutorDto.Cpf,
                Endereco = tutorDto.Endereco,
                Telefone = tutorDto.Telefone,
                Email = tutorDto.Email
            };
        }

        public static IEnumerable<TutorDTO> ToTutorDTOList(this IEnumerable<Tutor> tutores)
        {
            if (tutores is null || !tutores.Any())
                return new List<TutorDTO>();

            return tutores.Select(tutor => new TutorDTO
            {
                Id = tutor.Id,
                Nome = tutor.Nome,
                Idade = tutor.Idade,
                Sexo = tutor.Sexo,
                DataNascimento = tutor.DataNascimento,
                Cpf = tutor.Cpf,
                Endereco = tutor.Endereco,
                Telefone = tutor.Telefone,
                Email = tutor.Email
            }).ToList();
        }
    }
}
