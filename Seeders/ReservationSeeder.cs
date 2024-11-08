using EventsAPI.Models;
using Microsoft.EntityFrameworkCore;

public class ReservationSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>().HasData(
            new Reservation("confirmed", 1, 1)
            {
                Id = 1
            },
            new Reservation("confirmed", 2, 2)
            {
                Id = 2
            },
            new Reservation("pending", 3, 3)
            {
                Id = 3
            },
            new Reservation("confirmed", 4, 4)
            {
                Id = 4
            },
            new Reservation("cancelled", 5, 5)
            {
                Id = 
            }
        );
    }
}