using ReservasHotelPetAPI.Context;
using ReservasHotelPetAPI.Models;
using Microsoft.EntityFrameworkCore;
using ReservasHotelPetAPI.Repositories.Interfaces;
using ReservasHotelPetAPI.Pagination;
using X.PagedList;

namespace ReservasHotelPetAPI.Repositories
{
    public class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        public AnimalRepository(ApiReservasHotelPetContext context) : base(context)
        {
        }

        public async Task<IPagedList<Animal>> GetAnimaisAsync(AnimaisParameters animaisParameters)
        {
            var animais = await GetAllAsync();

            var animaisOrdenados = animais.OrderBy(a => a.Id).AsQueryable();

            var resultado = await animaisOrdenados.ToPagedListAsync(animaisParameters.PageNumber, animaisParameters.PageSize);

            return resultado;
        }

        public async Task<IPagedList<Animal>> GetAnimaisFiltroIdadeAsync(AnimaisFiltroIdade animaisFiltroIdadeParams)
        {
            var animais = await GetAllAsync();

            if (animaisFiltroIdadeParams.Idade.HasValue && !string.IsNullOrEmpty(animaisFiltroIdadeParams.IdadeCriterio))
            {
                if (animaisFiltroIdadeParams.IdadeCriterio.Equals("maior", StringComparison.OrdinalIgnoreCase))
                {
                    animais = animais.Where(a => a.Idade > animaisFiltroIdadeParams.Idade.Value).OrderBy(a => a.Idade);
                }
                else if (animaisFiltroIdadeParams.IdadeCriterio.Equals("menor", StringComparison.OrdinalIgnoreCase))
                {
                    animais = animais.Where(a => a.Idade < animaisFiltroIdadeParams.Idade.Value).OrderBy(a => a.Idade);
                }
                else if (animaisFiltroIdadeParams.IdadeCriterio.Equals("igual", StringComparison.OrdinalIgnoreCase))
                {
                    animais = animais.Where(a => a.Idade == animaisFiltroIdadeParams.Idade.Value).OrderBy(a => a.Idade);
                }
            }
            var animaisFiltrados = await animais.ToPagedListAsync(animaisFiltroIdadeParams.PageNumber, animaisFiltroIdadeParams.PageSize);

            return animaisFiltrados;
        }

        public async Task<IEnumerable<Animal>> GetAnimaisPorTutorAsync(int tutorId)
        {
            var animais = await GetAllAsync();

            var animaisTutores = animais.Where(a => a.TutorId == tutorId);

            return animaisTutores;
        }

    }
}
