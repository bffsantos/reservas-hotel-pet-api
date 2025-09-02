using ReservasHotelPetAPI.Context;
using ReservasHotelPetAPI.Repositories.Interfaces;

namespace ReservasHotelPetAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAnimalRepository? _animalRepo;
        private ITutorRepository? _tutorRepo;

        public ApiReservasHotelPetContext _context;

        public UnitOfWork(ApiReservasHotelPetContext context)
        {
            _context = context;
        }

        public IAnimalRepository AnimalRepository
        {
            get 
            { 
                return _animalRepo = _animalRepo ?? new AnimalRepository(_context); 
            }
        }
        public ITutorRepository TutorRepository
        {
            get
            {
                return _tutorRepo = _tutorRepo ?? new TutorRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
