using AspNetCoreGeneratedDocument;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ReservasHotelPetAPI.Context;
using ReservasHotelPetAPI.DTOs;
using ReservasHotelPetAPI.Filters;
using ReservasHotelPetAPI.Models;
using ReservasHotelPetAPI.Pagination;
using ReservasHotelPetAPI.Repositories.Interfaces;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace ReservasHotelPetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimaisController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        private readonly ILogger<AnimaisController> _logger;

        public AnimaisController(IUnitOfWork uof, ILogger<AnimaisController> logger, IMapper mapper)
        {
            _uof = uof;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("tutor/{id}")]
        public ActionResult<IEnumerable<AnimalDTO>> GetAnimaisTutores(int id)
        {
            var animais = _uof.AnimalRepository.GetAnimaisPorTutor(id);

            if (animais is null)
            {
                _logger.LogWarning($"Tutor com id = {id} não encontrado.");
                return NotFound($"Tutor com id = {id} não encontrado.");
            }

            var animaisDto = _mapper.Map<IEnumerable<AnimalDTO>>(animais);

            return Ok(animaisDto);
        }

        [HttpGet("pagination")]
        public ActionResult<IEnumerable<AnimalDTO>> Get([FromQuery] AnimaisParameters animaisParameters)
        {
            var animais = _uof.AnimalRepository.GetAnimais(animaisParameters);

            return ObterAnimais(animais);
        }

        [HttpGet("filtro/idade/pagination")]
        public ActionResult<IEnumerable<AnimalDTO>> GetAnimaisFiltroIdade([FromQuery] AnimaisFiltroIdade animaisFiltroParams)
        {
            var animais = _uof.AnimalRepository.GetAnimaisFiltroIdade(animaisFiltroParams);

            return ObterAnimais(animais);
        }

        public ActionResult<IEnumerable<AnimalDTO>> ObterAnimais(PagedList<Animal> animais) 
        {
            var metadata = new
            {
                animais.TotalCount,
                animais.PageSize,
                animais.CurrentPage,
                animais.TotalPages,
                animais.HasNext,
                animais.HasPrevious
            };

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));

            var animaisDto = _mapper.Map<IEnumerable<AnimalDTO>>(animais);

            return Ok(animaisDto);
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

            var animaisDto = _mapper.Map<IEnumerable<AnimalDTO>>(animais);

            return Ok(animaisDto);
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

            var animalDto = _mapper.Map<AnimalDTO>(animal);

            return animalDto;
        }

        [HttpPost]
        public ActionResult<AnimalDTO> Post(AnimalDTO animalDto)
        {
            if (animalDto is null)
            {
                _logger.LogWarning("Dados inválidos.");
                return BadRequest("Dados inválidos.");
            }

            var animal = _mapper.Map<Animal>(animalDto);

            var animalCriado = _uof.AnimalRepository.Create(animal);
            _uof.Commit();

            var animalCriadoDto = _mapper.Map<AnimalDTO>(animalCriado);

            return new CreatedAtRouteResult("ObterAnimal", new { id = animalCriadoDto.Id }, animalCriadoDto);
        }

        [HttpPatch("{id}/UpdatePartial")]
        public ActionResult<AnimalDTOUpdateResponse> Patch(int id, JsonPatchDocument<AnimalDTOUpdateRequset> patchAnimalDTO)
        {
            if(patchAnimalDTO is null || id <= 0)
                return BadRequest();

            var animal = _uof.AnimalRepository.Get(a => a.Id == id);

            if (animal is null)
                return NotFound();

            var animalUpdateRequest = _mapper.Map<AnimalDTOUpdateRequset>(animal);

            patchAnimalDTO.ApplyTo(animalUpdateRequest, ModelState);

            if (!ModelState.IsValid || !TryValidateModel(animalUpdateRequest))
                return BadRequest(ModelState);

            _mapper.Map(animalUpdateRequest, animal);

            _uof.AnimalRepository.Update(animal);
            _uof.Commit();

            return Ok(_mapper.Map<AnimalDTOUpdateResponse>(animal));
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult<AnimalDTO> Put(int id, AnimalDTO animalDto)
        {
            if (id != animalDto.Id)
            {
                _logger.LogWarning("Dados inválidos.");
                return BadRequest("Dados inválidos.");
            }

            var animal = _mapper.Map<Animal>(animalDto);

            var animalAtualizado = _uof.AnimalRepository.Update(animal);
            _uof.Commit();

            var animalAtualizadoDto = _mapper.Map<AnimalDTO>(animalAtualizado);

            return Ok(animalAtualizadoDto);
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

            var animalDeletadoDto = _mapper.Map<AnimalDTO>(animalDeletado);
            return Ok(animalDeletado);
        }
    }
}
