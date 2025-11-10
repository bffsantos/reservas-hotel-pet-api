using ReservasHotelPetAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ReservasHotelPetAPI.DTOs
{
    public class ReservaDTO
    {
        public int Id { get; set; }

        [Required]
        public int AnimalId { get; set; }

        [Required]
        public DateTime DataCheckIn { get; set; }

        [Required]
        public DateTime DataCheckOut { get; set; }

        [Required]
        public TipoReserva Tipo { get; set; }

        //[Required]
        //public StatusReserva Status { get; set; } = StatusReserva.Pendente;

        public string? Observacoes { get; set; }

        //public decimal ValorTotal { get; set; }
    }
}
