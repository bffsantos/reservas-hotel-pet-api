using ReservasHotelPetAPI.DTOs;
using ReservasHotelPetAPI.Models;
using ReservasHotelPetAPI.Models.Enums;

namespace ReservasHotelPetAPI.Repositories.Interfaces
{
    public interface IReservaRepository : IRepository<Reserva>
    {
        Task<IEnumerable<Reserva>> GetAllReservasAsync();
        Task<Reserva> GetReservaAsync(int id);
        Task<bool> PossuiReservaAsync(Reserva reserva);
        decimal CalculaValorReserva(Reserva reserva);
        decimal ObterPrecoDiaria(TipoReserva tipo);
    }
}
