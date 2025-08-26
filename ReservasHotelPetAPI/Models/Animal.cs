using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [Column("TutorId")]
        public int TutorId { get; set; }
        [JsonIgnore]
        public Tutor? Tutor { get; set; }
    }
}
