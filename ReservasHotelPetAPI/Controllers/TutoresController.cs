using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservasHotelPetAPI.Context;
using ReservasHotelPetAPI.Models;

namespace ReservasHotelPetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TutoresController : ControllerBase
    {
        private readonly ApiReservasHotelPetContext _context;

        public TutoresController(ApiReservasHotelPetContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tutor>> Get()
        {
            var tutores = _context.Tutores.ToList();
            if (tutores is null)
            {
                return NotFound("Tutores não encontrados.");
            }
            return tutores;
        }

        [HttpGet("Animais")]
        public ActionResult<IEnumerable<Tutor>> GetTutoresAnimais()
        {
            var tutores = _context.Tutores.Include(a => a.Animais).ToList();

            if (tutores is null)
                return NotFound("Tutores não encontrados.");

            return tutores;
        }

        [HttpGet("{id:int}", Name = "ObterTutor")]
        public ActionResult<Tutor> Get(int id)
        {
            var tutor = _context.Tutores.FirstOrDefault(a => a.Id == id);

            if (tutor == null)
                return NotFound("Tutor não encontrado.");

            return tutor;
        }

        [HttpPost]
        public ActionResult Post(Tutor tutor)
        {
            if (tutor is null)
                return BadRequest();

            _context.Tutores.Add(tutor);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterTutor", new { id = tutor.Id }, tutor);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Tutor tutor)
        {
            if (id != tutor.Id)
                return BadRequest();

            _context.Entry(tutor).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(tutor);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var tutor = _context.Tutores.FirstOrDefault(a => a.Id == id);

            if (tutor is null)
                return NotFound("Tutor não encontrado.");

            _context.Tutores.Remove(tutor);
            _context.SaveChanges();

            return Ok(tutor);
        }
    }
}
