using ReservasHotelPetAPI.Context;
using ReservasHotelPetAPI.Models;
using Microsoft.EntityFrameworkCore;
using ReservasHotelPetAPI.Repositories.Interfaces;
using ReservasHotelPetAPI.Pagination;

namespace ReservasHotelPetAPI.Repositories
{
    public class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        public AnimalRepository(ApiReservasHotelPetContext context) : base(context)
        {
        }

        public IEnumerable<Animal> GetAnimais(AnimaisParameters animaisParams)
        {
            return GetAll().OrderBy(a => a.Nome)
                .Skip((animaisParams.PageNumber - 1) * animaisParams.PageSize)
                .Take(animaisParams.PageSize).ToList();
        }

        public IEnumerable<Animal> GetAnimaisPorTutor(int tutorId)
        {
            return GetAll().Where(a => a.TutorId == tutorId);
        }

    }
}
