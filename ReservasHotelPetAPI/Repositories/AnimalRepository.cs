using ReservasHotelPetAPI.Context;
using ReservasHotelPetAPI.Models;
using Microsoft.EntityFrameworkCore;
using ReservasHotelPetAPI.Repositories.Interfaces;

namespace ReservasHotelPetAPI.Repositories
{
    public class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        public AnimalRepository(ApiReservasHotelPetContext context) : base(context)
        {
        }

        public IEnumerable<Animal> GetAnimaisPorTutor(int tutorId)
        {
            return GetAll().Where(a => a.TutorId == tutorId);
        }
    }
}
