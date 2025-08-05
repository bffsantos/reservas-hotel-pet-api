using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservasHotelPetAPI.Models
{
    [Table("Animais")]
    public class Animal
    {
        [Key]
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
        public int TutorId { get; set; }
        public Tutor? Tutor { get; set; }
    }
}
