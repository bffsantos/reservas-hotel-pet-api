using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservasHotelPetAPI.Models
{
    [Table("Tutores")]
    public class Tutor
    {
        public Tutor()
        {
            Animais = new Collection<Tutor>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        [StringLength(1)]
        public char Sexo { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        [StringLength(100)]
        public string? Endereco { get; set; }
        [Required]
        [StringLength(80)]
        public string? Telefone { get; set; }
        [Required]
        [StringLength(80)]
        public string? Email { get; set; }
        public ICollection<Tutor> Animais { get; set;}
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
