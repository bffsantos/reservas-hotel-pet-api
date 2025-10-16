using ReservasHotelPetAPI.Models;

namespace ReservasHotelPetAPI.DTOs.Mappings
{
    public static class AnimalDTOMappingExtensions
    {
        public static AnimalDTO ToAnimalDTO(this Animal animal)
        {
            if (animal is null)
                return null;

            return new AnimalDTO
            {
                Id = animal.Id,
                Nome = animal.Nome,
                Idade = animal.Idade,
                Raca = animal.Raca,
                Sexo = animal.Sexo,
                Tipo = animal.Tipo,
                TutorId = animal.TutorId
            };
        }

        public static Animal ToAnimal(this AnimalDTO animalDto)
        {
            if (animalDto is null)
                return null;

            return new Animal
            {
                Id = animalDto.Id,
                Nome = animalDto.Nome,
                Idade = animalDto.Idade,
                Raca = animalDto.Raca,
                Sexo = animalDto.Sexo,
                Tipo = animalDto.Tipo,
                TutorId = animalDto.TutorId
            };
        }

        public static IEnumerable<AnimalDTO> ToAnimalDTOList(this IEnumerable<Animal> animals)
        {
            if (animals is null || !animals.Any())
                return new List<AnimalDTO>();

            return animals.Select(animal => new AnimalDTO
            {
                Id = animal.Id,
                Nome = animal.Nome,
                Idade = animal.Idade,
                Raca = animal.Raca,
                Sexo = animal.Sexo,
                Tipo = animal.Tipo,
                TutorId = animal.TutorId
            }).ToList();
        }
    }
}
