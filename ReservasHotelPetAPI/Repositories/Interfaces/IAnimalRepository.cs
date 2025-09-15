using ReservasHotelPetAPI.Models;
using ReservasHotelPetAPI.Pagination;
using System.Collections;

namespace ReservasHotelPetAPI.Repositories.Interfaces
{
    public interface IAnimalRepository : IRepository<Animal>
    {
        IEnumerable<Animal> GetAnimais(AnimaisParameters animaisParams);
        IEnumerable<Animal> GetAnimaisPorTutor(int tutorId);
    }
}
