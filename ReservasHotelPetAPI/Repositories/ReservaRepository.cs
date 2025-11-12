using Humanizer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<bool> PossuiReservaAsync(Reserva reserva)
        {
            var countReservas = await _context.Reservas.Where(r =>
                r.Status != StatusReserva.Cancelada &&
                (
                    (reserva.DataCheckIn >= r.DataCheckIn && reserva.DataCheckIn < r.DataCheckOut) ||
                    (reserva.DataCheckOut > r.DataCheckIn && reserva.DataCheckOut <= r.DataCheckOut) ||
                    (reserva.DataCheckIn <= r.DataCheckIn && reserva.DataCheckOut >= r.DataCheckOut)
                )
            ).CountAsync();

            return countReservas >= CapacidadeMaxima;
        }

        public decimal CalculaValorReserva(Reserva reserva)
        {
            var precoDiaria = ObterPrecoDiaria(reserva.Tipo);
            var dias = Math.Max((reserva.DataCheckOut - reserva.DataCheckIn).Days, 1);
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

        public async Task<Reserva> GetReservaAsync(int id)
        {
            var reserva = await _context.Reservas.Include(r => r.Animal).FirstOrDefaultAsync(r => r.Id == id);

            return reserva;
        }

        public async Task<IEnumerable<Reserva>> GetAllReservasAsync()
        {
            var reservas = await _context.Reservas.Include(r => r.Animal).ToListAsync();

            return reservas;
        }
    }
}
