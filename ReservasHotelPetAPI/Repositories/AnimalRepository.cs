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

        public PagedList<Animal> GetAnimais(AnimaisParameters animaisParameters)
        {
            var animais = GetAll().OrderBy(a => a.Id).AsQueryable();
            var animaisOrdenados = PagedList<Animal>.ToPagedList(animais, animaisParameters.PageNumber, animaisParameters.PageSize);

            return animaisOrdenados;
        }

        public IEnumerable<Animal> GetAnimaisPorTutor(int tutorId)
        {
            return GetAll().Where(a => a.TutorId == tutorId);
        }

    }
}
