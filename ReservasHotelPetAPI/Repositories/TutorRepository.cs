using ReservasHotelPetAPI.Context;
using ReservasHotelPetAPI.Models;
using ReservasHotelPetAPI.Pagination;
using ReservasHotelPetAPI.Repositories.Interfaces;

namespace ReservasHotelPetAPI.Repositories
{
    public class TutorRepository : Repository<Tutor>, ITutorRepository
    {
        public TutorRepository(ApiReservasHotelPetContext context) : base(context)
        {
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

        public PagedList<Tutor> GetTutores(TutoresParameters tutoresParameters)
        {
            var tutores = GetAll().OrderBy(t => t.Id).AsQueryable();
            var tutoresOrdenados = PagedList<Tutor>.ToPagedList(tutores, tutoresParameters.PageNumber, tutoresParameters.PageSize);

            return tutoresOrdenados;
        }
    }
}
