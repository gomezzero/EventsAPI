using EventsAPI.Models;
using EventsAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Data
{
    public class UserSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User("Juan Perez", "juan.perez@email.com", PasswordHasher.HashPassword("password123"), true)
                {
                    Id = 1
                },
                new User("Maria Lopez", "maria.lopez@email.com", PasswordHasher.HashPassword("password123"), false)
                {
                    Id = 2
                },
                new User("Carlos Gomez", "carlos.gomez@email.com", PasswordHasher.HashPassword("password123"), true)
                {
                    Id = 3
                },

                new User("Ana Fernandez", "ana.fernandez@email.com", PasswordHasher.HashPassword("password123"), false)
                {
                    Id = 4
                },
                new User("Luis Torres", "luis.torres@email.com", PasswordHasher.HashPassword("password123"), true)
                {
                    Id = 5
                }
            );
        }
    }
}