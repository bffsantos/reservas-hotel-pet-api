using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReservasHotelPetAPI.Models;

namespace ReservasHotelPetAPI.Context
{
    public class ApiReservasHotelPetContext : IdentityDbContext<ApplicationUser>
    {
        public ApiReservasHotelPetContext(DbContextOptions<ApiReservasHotelPetContext> options) : base ( options ) { }

        public DbSet<Animal> Animais { get; set; }
        public DbSet<Tutor> Tutores { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
