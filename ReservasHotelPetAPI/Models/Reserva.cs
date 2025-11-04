using ReservasHotelPetAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ReservasHotelPetAPI.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AnimalId { get; set; }

        [JsonIgnore]
        [ForeignKey("AnimalId")]
        public Animal? Animal { get; set; }

        [Required]
        public DateTime DataCheckIn { get; set; }

        [Required]
        public DateTime DataCheckOut { get; set; }

        [Required]
        public TipoReserva Tipo { get; set; }

        [Required]
        public StatusReserva Status { get; set; } = StatusReserva.Pendente;

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorTotal { get; set; }

        [StringLength(255)]
        public string? Observacoes { get; set; }
    }
}
