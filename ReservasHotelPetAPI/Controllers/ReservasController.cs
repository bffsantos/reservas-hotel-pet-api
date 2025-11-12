using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservasHotelPetAPI.DTOs;
using ReservasHotelPetAPI.Models;
using ReservasHotelPetAPI.Models.Enums;
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
            var reservas = await _uof.ReservaRepository.GetAllReservasAsync();

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
            var reserva = await _uof.ReservaRepository.GetReservaAsync(id);

            if (reserva is null)
            {
                return NotFound("Reserva não encontrada.");
            }

            var reservaDto = _mapper.Map<ReservaDTO>(reserva);

            return Ok(reservaDto);
        }

        [HttpPost]
        public async Task<ActionResult<ReservaDTO>> Post(ReservaDTO reservaDto)
        {
            if (reservaDto is null)
            {
                return BadRequest("Dados inválidos.");
            }

            var reserva = _mapper.Map<Reserva>(reservaDto);
            
            if (await _uof.ReservaRepository.PossuiReservaAsync(reserva))
            {
                return BadRequest("Não há vagas para este período.");
            }

            var valorReserva = _uof.ReservaRepository.CalculaValorReserva(reserva);

            reserva.ValorTotal = valorReserva;

            var reservaCriada = _uof.ReservaRepository.Create(reserva);
            await _uof.CommitAsync();

            var reservaCriadaDto = _mapper.Map<ReservaDTO>(reservaCriada);

            return new CreatedAtRouteResult("ObterReserva", new { id = reservaCriadaDto.Id }, reservaCriadaDto);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<ReservaDTO>> Put(int id, ReservaDTO reservaDto)
        {
            if (id != reservaDto.Id)
                return BadRequest("Dados inválidos.");

            var reservaExistente = await _uof.ReservaRepository.GetReservaAsync(id);
            if (reservaExistente == null)
                return NotFound();

            reservaExistente.DataCheckIn = reservaDto.DataCheckIn;
            reservaExistente.DataCheckOut = reservaDto.DataCheckOut;
            reservaExistente.Tipo = Enum.Parse<TipoReserva>(reservaDto.Tipo);
            reservaExistente.Observacoes = reservaDto.Observacoes;

            reservaExistente.ValorTotal = _uof.ReservaRepository.CalculaValorReserva(reservaExistente);

            _uof.ReservaRepository.Update(reservaExistente);
            await _uof.CommitAsync();

            var reservaAtualizadaDto = _mapper.Map<ReservaDTO>(reservaExistente);
            return Ok(reservaAtualizadaDto);
        }

        [HttpPut("{id}/Cancelar")]
        public async Task<ActionResult<ReservaDTO>> CancelarReserva(int id)
        {
            var reserva = await _uof.ReservaRepository.GetReservaAsync(id);

            if (reserva == null)
                return NotFound("Reserva não encontrada.");

            if (reserva.Status == StatusReserva.Cancelada)
                return BadRequest("A reserva já está cancelada.");

            if (reserva.Status == StatusReserva.Confirmada)
                return BadRequest("Não é possível cancelar uma reserva já confirmada.");

            reserva.Status = StatusReserva.Cancelada;
            //reserva.DataAtualizacao = DateTime.UtcNow;

            await _uof.CommitAsync();

            var reservaAtualizadaDto = _mapper.Map<ReservaDTO>(reserva);

            return Ok(reservaAtualizadaDto);
        }

        [HttpPut("{id}/Confirmar")]
        public async Task<IActionResult> ConfirmarReserva(int id)
        {
            var reserva = await _uof.ReservaRepository.GetReservaAsync(id);

            if (reserva == null)
                return NotFound("Reserva não encontrada.");

            if (reserva.Status == StatusReserva.Cancelada)
                return BadRequest("Não é possível confirmar uma reserva cancelada.");

            if (reserva.Status == StatusReserva.Confirmada)
                return BadRequest("A reserva já foi confirmada.");

            reserva.Status = StatusReserva.Confirmada;
            //reserva.DataAtualizacao = DateTime.UtcNow;

            await _uof.CommitAsync();

            var reservaAtualizadaDto = _mapper.Map<ReservaDTO>(reserva);

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
