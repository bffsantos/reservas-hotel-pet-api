using Microsoft.AspNetCore.Mvc;
using ReservasHotelPetAPI.Context;
using ReservasHotelPetAPI.Models;
using System.Collections;

namespace ReservasHotelPetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimaisController : ControllerBase
    {
        private readonly ApiReservasHotelPetContext _context;

        public AnimaisController(ApiReservasHotelPetContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Animal>> Get()
        {
            var animais = _context.Animais.ToList();
            if(animais is null)
            {
                return NotFound("Animais não encontrados.");
            }
            return animais;
        }
    }
}
