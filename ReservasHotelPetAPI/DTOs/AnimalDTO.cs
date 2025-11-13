using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReservasHotelPetAPI.DTOs
{
    public class AnimalDTO
    {
        public int Id { get; set; }
        [StringLength(80)]
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        [StringLength(50)]
        public string? Tipo { get; set; }
        [StringLength(50)]
        public string? Raca { get; set; }
        [Column("TutorId")]
        public int TutorId { get; set; }
    }
}
