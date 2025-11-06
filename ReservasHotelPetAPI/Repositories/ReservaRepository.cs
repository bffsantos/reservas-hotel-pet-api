using Humanizer;
using Microsoft.EntityFrameworkCore;
using ReservasHotelPetAPI.Context;
using ReservasHotelPetAPI.DTOs;
using ReservasHotelPetAPI.Models;
using ReservasHotelPetAPI.Models.Enums;
using ReservasHotelPetAPI.Repositories.Interfaces;

namespace ReservasHotelPetAPI.Repositories
{
    public class ReservaRepository : Repository<Reserva>, IReservaRepository
    {
        private const int CapacidadeMaxima = 20;

        public ReservaRepository(ApiReservasHotelPetContext context) : base(context)
        {
        }

        public async Task<bool> PossuiReservaAsync(ReservaDTO reservaDto)
        {
            var reservas = await GetAllAsync();
            
            var countReservas =  await _context.Reservas.Where(r =>
                r.Status != StatusReserva.Cancelada &&
                (
                    (reservaDto.DataCheckIn >= r.DataCheckIn && reservaDto.DataCheckIn < r.DataCheckOut) ||
                    (reservaDto.DataCheckOut > r.DataCheckIn && reservaDto.DataCheckOut <= r.DataCheckOut) ||
                    (reservaDto.DataCheckIn <= r.DataCheckIn && reservaDto.DataCheckOut >= r.DataCheckOut)
                )
            ).CountAsync();

            return countReservas >= CapacidadeMaxima;
        }

        public decimal CalculaValorReserva(ReservaDTO reservaDto)
        {
            var precoDiaria = ObterPrecoDiaria(reservaDto.Tipo);
            var dias = Math.Max((reservaDto.DataCheckOut - reservaDto.DataCheckIn).Days, 1);
            var total = precoDiaria * dias;

            return total;
        }

        public decimal ObterPrecoDiaria(TipoReserva tipo)
        {
            return tipo switch
            {
                TipoReserva.Basico => 80m,
                TipoReserva.Premium => 120m,
                TipoReserva.Vip => 180m,
                _ => 0m
            };
        }
    }
}
