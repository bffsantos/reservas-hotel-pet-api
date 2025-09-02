using ReservasHotelPetAPI.Models;

namespace ReservasHotelPetAPI.Repositories.Interfaces
{
    public interface ITutorRepository
    {
        IEnumerable<Tutor> GetTutores();
        Tutor GetTutor(int id);
        Tutor Create(Tutor tutor);
        Tutor Update(Tutor tutor);
        Tutor Delete(int id);
    }
}
