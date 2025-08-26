using Microsoft.EntityFrameworkCore;
using ReservasHotelPetAPI.Models;

namespace ReservasHotelPetAPI.Context
{
    public class ApiReservasHotelPetContext : DbContext
    {
        public ApiReservasHotelPetContext(DbContextOptions<ApiReservasHotelPetContext> options) : base ( options )
        {
                
        }

        public DbSet<Animal> Animais { get; set; }
        public DbSet<Tutor> Tutores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
