using System.ComponentModel.DataAnnotations;

namespace ReservasHotelPetAPI.DTOs
{
    public class AnimalDTOUpdateRequset : IValidatableObject
    {
        [StringLength(50, ErrorMessage = "Tipo deve conter menos de 50 caracteres.")]
        public string? Tipo { get; set; }
        public string? Raca { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Raca))
            {
                yield return new ValidationResult("Raça está com valor nulo.", new[] { nameof(this.Raca) });
            }

            if (Raca.Length > 50)
            {
                yield return new ValidationResult("Raça deve conter menos de 50 caracteres", new[] { nameof(this.Raca) });
            }
        }
    }
}