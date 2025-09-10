using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservasHotelPetAPI.DTOs
{
    public class AnimalDTOUpdateResponse
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public string? Tipo { get; set; }
        public string? Raca { get; set; }
        public int TutorId { get; set; }
    }
}