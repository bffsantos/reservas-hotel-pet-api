using ReservasHotelPetAPI.Models;

namespace ReservasHotelPetAPI.Repositories.Interfaces
{
    public interface IAnimalRepository : IRepository<Animal>
    {
        IEnumerable<Animal> GetAnimaisPorTutor(int tutorId);
    }
}
