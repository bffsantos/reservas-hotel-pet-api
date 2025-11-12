using ReservasHotelPetAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReservasHotelPetAPI.DTOs
{
    public class ReservaDTO
    {
        public int Id { get; set; }

        public int AnimalId { get; set; }

        public string? AnimalNome { get; set; }

        [Required]
        public DateTime DataCheckIn { get; set; }

        [Required]
        public DateTime DataCheckOut { get; set; }

        [Required]
        public string? Tipo { get; set; }

        public string? Status { get; set; } = "Pendente";

        public string? Observacoes { get; set; }

        public decimal ValorTotal { get; set; }
    }
}
