using ReservasHotelPetAPI.Models;
using ReservasHotelPetAPI.Pagination;
using System.Collections;

namespace ReservasHotelPetAPI.Repositories.Interfaces
{
    public interface IAnimalRepository : IRepository<Animal>
    {
        PagedList<Animal> GetAnimais(AnimaisParameters animaisParams);
        IEnumerable<Animal> GetAnimaisPorTutor(int tutorId);
    }
}
