using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservasHotelPetAPI.Context;
using ReservasHotelPetAPI.DTOs;
using ReservasHotelPetAPI.DTOs.Mappings;
using ReservasHotelPetAPI.Models;
using ReservasHotelPetAPI.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ReservasHotelPetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TutoresController : ControllerBase
    {
        //private readonly IRepository<Tutor> _repository;
        private readonly IUnitOfWork _uof;
        private readonly ILogger<TutoresController> _logger;

        public TutoresController(IUnitOfWork uof, ILogger<TutoresController> logger)
        {
            _uof = uof;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TutorDTO>> Get()
        {
            var tutores = _uof.TutorRepository.GetAll();

            if(tutores is null)
            {
                _logger.LogWarning("Não existem tutores.");
                return NotFound("Não existem tutores.");
            }

            var tutoresDto = TutorDTOMappingExtensions.ToTutorDTOList(tutores);

            return Ok(tutoresDto);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterTutor")]
        public ActionResult<TutorDTO> Get(int id)
        {
            var tutor = _uof.TutorRepository.Get(t => t.Id == id);

            if (tutor is null)
            {
                _logger.LogWarning($"Tutor com id = {id} não encontrado.");
                return NotFound($"Tutor com id = {id} não encontrado.");
            }

            var tutorDto = TutorDTOMappingExtensions.ToTutorDTO(tutor);

            return Ok(tutorDto);
        }

        [HttpPost]
        public ActionResult<TutorDTO> Post(TutorDTO tutorDto)
        {
            if (tutorDto is null)
            {
                _logger.LogWarning("Dados inválidos.");
                return BadRequest("Dados inválidos.");
            }

            var tutor = TutorDTOMappingExtensions.ToTutor(tutorDto);

            var tutorCriado = _uof.TutorRepository.Create(tutor);
            _uof.Commit();

            var novoTutorDto = TutorDTOMappingExtensions.ToTutorDTO(tutor);

            return new CreatedAtRouteResult("ObterTutor", new { id = novoTutorDto.Id }, novoTutorDto);
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult<TutorDTO> Put(int id, TutorDTO tutorDto)
        {
            if (id != tutorDto.Id)
            {
                _logger.LogWarning("Dados inválidos.");
                return BadRequest("Dados inválidos.");
            }

            var tutor = TutorDTOMappingExtensions.ToTutor(tutorDto);

            var tutorAtualizado = _uof.TutorRepository.Update(tutor);
            _uof.Commit();

            var tutorAtualizadoDto = TutorDTOMappingExtensions.ToTutorDTO(tutor);

            return Ok(tutorAtualizadoDto);
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<TutorDTO> Delete(int id)
        {
            var tutor = _uof.TutorRepository.Get(t => t.Id == id);

            if (tutor is null)
            {
                _logger.LogWarning($"Tutor com id = {id} não encontrado.");
                return NotFound($"Tutor com id = {id} não encontrado.");
            }

            var tutorDeletado = _uof.TutorRepository.Delete(tutor);
            _uof.Commit();

            var tutorDeletadoDto = TutorDTOMappingExtensions.ToTutorDTO(tutor);

            return Ok(tutorDeletadoDto);
        }
    }
}
