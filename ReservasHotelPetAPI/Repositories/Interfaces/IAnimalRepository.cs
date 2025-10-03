using ReservasHotelPetAPI.Models;
using ReservasHotelPetAPI.Pagination;
using System.Collections;
using X.PagedList;

namespace ReservasHotelPetAPI.Repositories.Interfaces
{
    public interface IAnimalRepository : IRepository<Animal>
    {
        Task<IPagedList<Animal>> GetAnimaisAsync(AnimaisParameters animaisParams);
        Task<IPagedList<Animal>> GetAnimaisFiltroIdadeAsync(AnimaisFiltroIdade animaisFiltroIdadeParams);
        Task<IEnumerable<Animal>> GetAnimaisPorTutorAsync(int tutorId);
    }
}
