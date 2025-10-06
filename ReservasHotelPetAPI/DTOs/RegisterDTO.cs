using System.ComponentModel.DataAnnotations;

namespace ReservasHotelPetAPI.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Passwrod is required")]
        public string? Passwrod { get; set; }
    }
}
