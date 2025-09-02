using ReservasHotelPetAPI.Context;
using ReservasHotelPetAPI.Models;
using ReservasHotelPetAPI.Repositories.Interfaces;

namespace ReservasHotelPetAPI.Repositories
{
    public class TutorRepository : ITutorRepository
    {
        private readonly ApiReservasHotelPetContext _context;

        public TutorRepository(ApiReservasHotelPetContext context)
        {
            _context = context;
        }
        public IEnumerable<Tutor> GetTutores()
        {
            return _context.Tutores.ToList();
        }

        public Tutor GetTutor(int id)
        {
            return _context.Tutores.FirstOrDefault(t => t.Id == id);
        }

        public Tutor Create(Tutor tutor)
        {
            if(tutor == null)
                throw new ArgumentNullException(nameof(tutor));

            _context.Tutores.Add(tutor);
            _context.SaveChanges();

            return tutor;
        }

        public Tutor Update(Tutor tutor)
        {
            if (tutor == null)
                throw new ArgumentNullException(nameof(tutor));

            _context.Entry(tutor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return tutor;
        }

        public Tutor Delete(int id)
        {
            var tutor = _context.Tutores.Find(id);

            if (tutor == null)
                throw new ArgumentNullException(nameof(tutor));

            _context.Tutores.Remove(tutor);
            _context.SaveChanges();

            return tutor;
        }
    }
}
