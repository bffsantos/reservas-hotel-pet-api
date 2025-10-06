using System.ComponentModel.DataAnnotations;

namespace ReservasHotelPetAPI.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Username is required")]
        public string? Username {  get; set; }

        [Required(ErrorMessage = "Passwrod is required")]
        public string? Passwrod { get; set; }
    }
}
