using ReservasHotelPetAPI.Context;
using ReservasHotelPetAPI.Models;
using Microsoft.EntityFrameworkCore;
using ReservasHotelPetAPI.Repositories.Interfaces;

namespace ReservasHotelPetAPI.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ApiReservasHotelPetContext _context;

        public AnimalRepository(ApiReservasHotelPetContext context)
        {
            _context = context;
        }

        public IEnumerable<Animal> GetAnimais()
        {
            return _context.Animais.ToList();
        }

        public Animal GetAnimal(int id)
        {
            return _context.Animais.FirstOrDefault(a => a.Id == id);
        }

        public Animal Create(Animal animal)
        {
            if (animal == null)
                throw new ArgumentNullException(nameof(animal));

            _context.Animais.Add(animal);
            _context.SaveChanges();

            return animal;
        }

        public Animal Update(Animal animal)
        {
            if (animal == null)
                throw new ArgumentNullException(nameof(animal));

            _context.Entry(animal).State = EntityState.Modified;
            _context.SaveChanges();

            return animal;
        }

        public Animal Delete(int id)
        {
            var animal = _context.Animais.Find(id);

            if (animal == null)
                throw new ArgumentNullException(nameof(animal));

            _context.Animais.Remove(animal);
            _context.SaveChanges();
            return animal;
        }               
    }
}
