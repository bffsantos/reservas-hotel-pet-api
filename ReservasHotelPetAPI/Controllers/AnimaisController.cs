using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservasHotelPetAPI.Context;
using ReservasHotelPetAPI.DTOs;
using ReservasHotelPetAPI.Filters;
using ReservasHotelPetAPI.Models;
using ReservasHotelPetAPI.Repositories.Interfaces;
using System.Collections;

namespace ReservasHotelPetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimaisController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly ILogger<AnimaisController> _logger;

        public AnimaisController(IUnitOfWork uof, ILogger<AnimaisController> logger)
        {
            _uof = uof;
            _logger = logger;
        }

        [HttpGet("tutor/{id}")]
        public ActionResult<IEnumerable<AnimalDTO>> GetAnimaisTutores(int id)
        {
            var animal = _uof.AnimalRepository.GetAnimaisPorTutor(id);

            if (animal is null)
            {
                _logger.LogWarning($"Tutor com id = {id} não encontrado.");
                return NotFound($"Tutor com id = {id} não encontrado.");
            }

            return Ok(animal);
        }

        [HttpGet]
        public ActionResult<IEnumerable<AnimalDTO>> Get()
        {
            var animais = _uof.AnimalRepository.GetAll();

            if (animais is null)
            {
                _logger.LogWarning("Animais não encontrados.");
                return NotFound("Animais não encontrados.");
            }

            return Ok(animais);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterAnimal")]
        public ActionResult<AnimalDTO> Get(int id)
        {
            var animal = _uof.AnimalRepository.Get(a => a.Id == id);

            if (animal is null)
            {
                _logger.LogWarning("Animal não encontrado.");
                return NotFound("Animal não encontrado.");
            }

            return animal;
        }

        [HttpPost]
        public ActionResult<AnimalDTO> Post(AnimalDTO animalDto)
        {
            if (animalDto is null)
            {
                _logger.LogWarning("Dados inválidos.");
                return BadRequest("Dados inválidos.");
            }

            var animalaCriado = _uof.AnimalRepository.Create(animalDto);
            _uof.Commit();

            return new CreatedAtRouteResult("ObterAnimal", new { id = animalaCriado.Id }, animalaCriado);
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult<AnimalDTO Put(int id, AnimalDTO animalDto)
        {
            if (id != animalDto.Id)
            {
                _logger.LogWarning("Dados inválidos.");
                return BadRequest("Dados inválidos.");
            }

            var animalAtualizado = _uof.AnimalRepository.Update(animalDto);
            _uof.Commit();

            return Ok(animalAtualizado);
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<AnimalDTO> Delete(int id)
        {
            var animal = _uof.AnimalRepository.Get(a => a.Id == id);

            if (animal is null)
            {
                _logger.LogWarning("Animal não encontrado.");
                return NotFound("Animal não encontrado.");
            }

            var animalDeletado = _uof.AnimalRepository.Delete(animal);
            _uof.Commit();

            return Ok(animalDeletado);
        }
    }
}
