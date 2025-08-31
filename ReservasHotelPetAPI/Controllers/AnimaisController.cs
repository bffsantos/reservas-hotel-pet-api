using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservasHotelPetAPI.Context;
using ReservasHotelPetAPI.Models;
using System.Collections;

namespace ReservasHotelPetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimaisController : ControllerBase
    {
        private readonly ApiReservasHotelPetContext _context;

        public AnimaisController(ApiReservasHotelPetContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> Get()
        {
            try
            {
                var animais = await _context.Animais.AsNoTracking().ToListAsync();

                if (animais is null)
                    return NotFound("Animais não encontrados.");

                return animais;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação.");
            }
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterAnimal")]
        public async Task<ActionResult<Animal>> Get(int id)
        {
            var animal = await _context.Animais.FirstOrDefaultAsync(a => a.Id == id);

            if (animal == null)
                return NotFound("Animal não encontrado.");

            return animal;
        }

        [HttpPost]
        public ActionResult Post(Animal animal)
        {
            if (animal is null)
                return BadRequest();

            _context.Animais.Add(animal);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterAnimal", new { id = animal.Id }, animal);
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult Put(int id, Animal animal)
        {
            if (id != animal.Id)
                return BadRequest();

            _context.Entry(animal).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(animal);
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult Delete(int id)
        {
            var animal = _context.Animais.FirstOrDefault(a => a.Id == id);

            if (animal is null)
                return NotFound("Animal não encontrado.");

            _context.Animais.Remove(animal);
            _context.SaveChanges();

            return Ok(animal);
        }
    }
}
