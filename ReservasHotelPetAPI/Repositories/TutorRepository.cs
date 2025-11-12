using ReservasHotelPetAPI.Context;
using ReservasHotelPetAPI.Models;
using ReservasHotelPetAPI.Pagination;
using ReservasHotelPetAPI.Repositories.Interfaces;
using X.PagedList;

namespace ReservasHotelPetAPI.Repositories
{
    public class TutorRepository : Repository<Tutor>, ITutorRepository
    {
        public TutorRepository(ApiReservasHotelPetContext context) : base(context)
        {
        }

        public async Task<IPagedList<Tutor>> GetTutoresAsync(TutoresParameters tutoresParams)
        {
            var tutores = await GetAllAsync();

            var tutoresOrdenados = tutores.OrderBy(t => t.Id).AsQueryable();

            //var resultado = PagedList<Tutor>.ToPagedList(tutoresOrdenados, tutoresParams.PageNumber, tutoresParams.PageSize);
            var resultado = await tutoresOrdenados.ToPagedListAsync(tutoresParams.PageNumber, tutoresParams.PageSize);

            return resultado;
        }

        public async Task<IPagedList<Tutor>> GetTutoresFiltroNomeAsync(TutoresFiltroNome tutoresFiltroParams)
        {
            var tutores = await GetAllAsync();

            if (!string.IsNullOrEmpty(tutoresFiltroParams.Nome))
            {
                tutores = tutores.Where(t => t.Nome.Contains(tutoresFiltroParams.Nome));
            }

            //var tutoresFiltrados = PagedList<Tutor>.ToPagedList(tutores.AsQueryable(), tutorFiltroParams.PageNumber, tutorFiltroParams.PageSize);
            var tutoresFiltrados = await tutores.ToPagedListAsync(tutoresFiltroParams.PageNumber, tutoresFiltroParams.PageSize);

            return tutoresFiltrados;
        }
    }
}
