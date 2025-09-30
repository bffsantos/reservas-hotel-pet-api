namespace ReservasHotelPetAPI.Pagination
{
    public class AnimaisFiltroIdade : QueryStringParameters
    {
        public int? Idade { get; set; }
        public string? IdadeCriterio { get; set; }
    }
}