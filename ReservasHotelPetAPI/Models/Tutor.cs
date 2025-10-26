using Newtonsoft.Json.Serialization;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ReservasHotelPetAPI.Models
{
    [Table("Tutores")]
    public class Tutor
    {
        public Tutor()
        {
            Animais = new Collection<Animal>();
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "O nome deve ter entre {2} e {1} caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo idade é obrigatório.")]
        [Range(18, 200, ErrorMessage = "A idade deve estar entre {1} e {2} anos")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O campo sexo é obrigatório.")]
        public char Sexo { get; set; }

        [Required(ErrorMessage = "O campo data de nascimento é obrigatório.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [StringLength(14)]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "O campo endereço é obrigatório.")]
        [StringLength(100)]
        public string? Endereco { get; set; }

        [Required(ErrorMessage = "O campo telefone é obrigatório.")]
        [StringLength(80)]
        //[Phone]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório.")]
        [StringLength(80)]
        //[EmailAddress]
        public string? Email { get; set; }

        [JsonIgnore]
        public ICollection<Animal> Animais { get; set; }
    }
}
