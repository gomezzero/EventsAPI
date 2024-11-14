using EventsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Llamar a los seeder
            UserSeeder.Seed(modelBuilder);
            EventSeeder.Seed(modelBuilder);
            ReservationSeeder.Seed(modelBuilder);
        }
    }
}