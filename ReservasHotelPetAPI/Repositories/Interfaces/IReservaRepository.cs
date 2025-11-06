using ReservasHotelPetAPI.DTOs;
using ReservasHotelPetAPI.Models;
using ReservasHotelPetAPI.Models.Enums;

namespace ReservasHotelPetAPI.Repositories.Interfaces
{
    public interface IReservaRepository : IRepository<Reserva>
    {

        Task<bool> PossuiReservaAsync(ReservaDTO reservaDto);
        decimal CalculaValorReserva(ReservaDTO reservaDto);
        decimal ObterPrecoDiaria(TipoReserva tipo);
    }
}
