using ReservasHotelPetAPI.Models;

namespace ReservasHotelPetAPI.Repositories.Interfaces
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> GetAnimais();
        Animal GetAnimal(int id);
        Animal Create(Animal animal);
        Animal Update(Animal animal);
        Animal Delete(int id);
    }
}
