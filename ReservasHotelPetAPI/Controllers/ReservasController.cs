using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReservasHotelPetAPI.DTOs;
using ReservasHotelPetAPI.Models;
using ReservasHotelPetAPI.Repositories.Interfaces;

namespace ReservasHotelPetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public ReservasController(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaDTO>>> Get()
        {
            var reservas = await _uof.ReservaRepository.GetAllAsync();

            if (reservas is null)
            {
                return NotFound("Reservas não encontradas.");
            }

            var reservasDto = _mapper.Map<IEnumerable<ReservaDTO>>(reservas);

            return Ok(reservasDto);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterReserva")]
        public async Task<ActionResult<ReservaDTO>> Get(int id)
        {
            var reserva = await _uof.ReservaRepository.GetAsync(r => r.Id == id);

            if (reserva is null)
            {
                return NotFound("Reserva não encontrada.");
            }

            var reservaDto = _mapper.Map<ReservaDTO>(reserva);

            return reservaDto;
        }

        [HttpPost]
        public async Task<ActionResult<ReservaDTO>> Post(ReservaDTO reservaDto)
        {
            if (reservaDto is null)
            {
                return BadRequest("Dados inválidos.");
            }

            var reserva = _mapper.Map<Reserva>(reservaDto);

            var reservaCriada = _uof.ReservaRepository.Create(reserva);
            await _uof.CommitAsync();

            var reservaCriadaDto = _mapper.Map<ReservaDTO>(reservaCriada);

            return new CreatedAtRouteResult("ObterReserva", new { id = reservaCriadaDto.Id }, reservaCriadaDto);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<ReservaDTO>> Put(int id, ReservaDTO reservaDto)
        {
            if (id != reservaDto.Id)
            {
                return BadRequest("Dados inválidos.");
            }

            var reserva = _mapper.Map<Reserva>(reservaDto);

            var reservaAtualizada = _uof.ReservaRepository.Update(reserva);
            await _uof.CommitAsync();

            var reservaAtualizadaDto = _mapper.Map<ReservaDTO>(reservaAtualizada);

            return Ok(reservaAtualizadaDto);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult<ReservaDTO>> Delete(int id)
        {
            var reserva = await _uof.ReservaRepository.GetAsync(r => r.Id == id);

            if (reserva is null)
            {
                return NotFound("Reserva não encontrada.");
            }

            var reservaDeletado = _uof.ReservaRepository.Delete(reserva);
            await _uof.CommitAsync();

            var reservaDeletadoDto = _mapper.Map<ReservaDTO>(reservaDeletado);
            return Ok(reservaDeletado);
        }
    }
}
