using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ReservasHotelPetAPI.Context;
using ReservasHotelPetAPI.DTOs;
using ReservasHotelPetAPI.DTOs.Mappings;
using ReservasHotelPetAPI.Models;
using ReservasHotelPetAPI.Pagination;
using ReservasHotelPetAPI.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace ReservasHotelPetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TutoresController : ControllerBase
    {
        //private readonly IRepository<Tutor> _repository;
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        private readonly ILogger<TutoresController> _logger;

        public TutoresController(IUnitOfWork uof, ILogger<TutoresController> logger, IMapper mapper)
        {
            _uof = uof;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TutorDTO>>> Get()
        {
            var tutores = await _uof.TutorRepository.GetAllAsync();

            if(tutores is null)
            {
                _logger.LogWarning("Não existem tutores.");
                return NotFound("Não existem tutores.");
            }

            var tutoresDto = _mapper.Map<IEnumerable<TutorDTO>>(tutores);

            return Ok(tutoresDto);
        }

        [HttpGet("pagination")]
        public async Task<ActionResult<IEnumerable<TutorDTO>>> Get([FromQuery] TutoresParameters tutoresParameters)
        {
            var tutores = await _uof.TutorRepository.GetTutoresAsync(tutoresParameters);

            return ObterTutores(tutores);
        }

        [HttpGet("filtro/nome/pagination")]
        public async Task<ActionResult<IEnumerable<TutorDTO>>> GetTutoresFiltroNomeAsync([FromQuery] TutoresFiltroNome tutoresFiltroNome)
        {
            var tutoresFiltrados = await _uof.TutorRepository.GetTutoresFiltroNomeAsync(tutoresFiltroNome);

            return ObterTutores(tutoresFiltrados);
        }

        private ActionResult<IEnumerable<TutorDTO>> ObterTutores(IPagedList<Tutor> tutores)
        {
            var metadata = new
            {
                tutores.Count,
                tutores.PageSize,
                tutores.PageCount,
                tutores.TotalItemCount,
                tutores.HasNextPage,
                tutores.HasPreviousPage
            };

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));

            var tutoresDto = _mapper.Map<IEnumerable<TutorDTO>>(tutores);

            return Ok(tutoresDto);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterTutor")]
        public async Task<ActionResult<TutorDTO>> Get(int id)
        {
            var tutor = await _uof.TutorRepository.GetAsync(t => t.Id == id);

            if (tutor is null)
            {
                _logger.LogWarning($"Tutor com id = {id} não encontrado.");
                return NotFound($"Tutor com id = {id} não encontrado.");
            }

            var tutorDto = _mapper.Map<TutorDTO>(tutor);

            return Ok(tutorDto);
        }

        [HttpPost]
        public async Task<ActionResult<TutorDTO>> Post(TutorDTO tutorDto)
        {
            if (tutorDto is null)
            {
                _logger.LogWarning("Dados inválidos.");
                return BadRequest("Dados inválidos.");
            }

            var tutor = _mapper.Map<Tutor>(tutorDto);

            var tutorCriado = _uof.TutorRepository.Create(tutor);
            await _uof.CommitAsync();

            var novoTutorDto = _mapper.Map<TutorDTO>(tutorCriado);

            return new CreatedAtRouteResult("ObterTutor", new { id = novoTutorDto.Id }, novoTutorDto);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<TutorDTO>> Put(int id, TutorDTO tutorDto)
        {
            if (id != tutorDto.Id)
            {
                _logger.LogWarning("Dados inválidos.");
                return BadRequest("Dados inválidos.");
            }

            var tutor = _mapper.Map<Tutor>(tutorDto);

            var tutorAtualizado = _uof.TutorRepository.Update(tutor);
            await _uof.CommitAsync();

            var tutorAtualizadoDto = _mapper.Map<TutorDTO>(tutorAtualizado);

            return Ok(tutorAtualizadoDto);
        }

        [HttpDelete("{id:int:min(1)}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<TutorDTO>> Delete(int id)
        {
            var tutor = await _uof.TutorRepository.GetAsync(t => t.Id == id);

            if (tutor is null)
            {
                _logger.LogWarning($"Tutor com id = {id} não encontrado.");
                return NotFound($"Tutor com id = {id} não encontrado.");
            }

            var tutorDeletado = _uof.TutorRepository.Delete(tutor);
            await _uof.CommitAsync();

            var tutorDeletadoDto = _mapper.Map<TutorDTO>(tutorDeletado);

            return Ok(tutorDeletadoDto);
        }
    }
}
