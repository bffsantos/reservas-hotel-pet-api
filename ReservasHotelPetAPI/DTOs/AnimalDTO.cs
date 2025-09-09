using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReservasHotelPetAPI.DTOs
{
    public class AnimalDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public char Sexo { get; set; }
        [Required]
        [StringLength(50)]
        public string? Tipo { get; set; }
        [Required]
        [StringLength(50)]
        public string? Raca { get; set; }
        [Column("TutorId")]
        public int TutorId { get; set; }
    }
}
