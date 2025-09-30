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

        public PagedList<Animal> GetAnimaisFiltroIdade(AnimaisFiltroIdade animaisFiltroIdadeParams)
        {
            var animais = GetAll().AsQueryable();

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
            var animaisFiltrados = PagedList<Animal>.ToPagedList(animais, animaisFiltroIdadeParams.PageNumber, animaisFiltroIdadeParams.PageSize);
            return animaisFiltrados;
        }

        public IEnumerable<Animal> GetAnimaisPorTutor(int tutorId)
        {
            return GetAll().Where(a => a.TutorId == tutorId);
        }

    }
}
