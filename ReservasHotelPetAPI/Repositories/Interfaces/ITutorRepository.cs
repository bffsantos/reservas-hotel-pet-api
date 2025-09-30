using ReservasHotelPetAPI.Models;
using ReservasHotelPetAPI.Pagination;

namespace ReservasHotelPetAPI.Repositories.Interfaces
{
    public interface ITutorRepository : IRepository<Tutor>
    {
        PagedList<Tutor> GetTutores(TutoresParameters tutoresParameters);
    }
}
