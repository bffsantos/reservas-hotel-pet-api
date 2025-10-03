using ReservasHotelPetAPI.Models;
using ReservasHotelPetAPI.Pagination;
using X.PagedList;

namespace ReservasHotelPetAPI.Repositories.Interfaces
{
    public interface ITutorRepository : IRepository<Tutor>
    {
        Task<IPagedList<Tutor>> GetTutoresAsync(TutoresParameters tutoresParameters);
        Task<IPagedList<Tutor>> GetTutoresFiltroNomeAsync(TutoresFiltroNome tutorFiltroParams);
    }
}
