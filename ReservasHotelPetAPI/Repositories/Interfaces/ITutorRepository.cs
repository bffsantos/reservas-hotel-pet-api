using ReservasHotelPetAPI.Models;
using ReservasHotelPetAPI.Pagination;

namespace ReservasHotelPetAPI.Repositories.Interfaces
{
    public interface ITutorRepository : IRepository<Tutor>
    {
        PagedList<Tutor> GetTutoresFIltroNome(TutoresFiltroNome tutorFiltroParams);
        PagedList<Tutor> GetTutores(TutoresParameters tutoresParameters);
    }
}
