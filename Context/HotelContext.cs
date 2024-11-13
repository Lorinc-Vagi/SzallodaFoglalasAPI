using Microsoft.EntityFrameworkCore;
using SzallodaFoglalasAPI.Entities;

namespace SzallodaFoglalasAPI.Context
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> o):base(o) { }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
