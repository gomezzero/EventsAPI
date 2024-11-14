using EventsAPI.Models;
using Microsoft.EntityFrameworkCore;

public class EventSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>().HasData(
            new Event("Concert", "Live music concert with local bands", DateOnly.FromDateTime(DateTime.Now.AddDays(30)),  TimeOnly.Parse("19:00"), "Downtown Arena", 500, 500, "active", "https://example.com/concert.jpg")
            {
                Id = 1
            },
            new Event("Workshop", "Workshop on web development using .NET", DateOnly.FromDateTime(DateTime.Now.AddDays(10)),  TimeOnly.Parse("09:00"), "Tech Hub", 50, 50, "active", "https://example.com/workshop.jpg")
            {
                Id = 2
            },
            new Event("Conference", "Annual tech conference featuring keynote speakers", DateOnly.FromDateTime(DateTime.Now.AddDays(60)),  TimeOnly.Parse("08:00"), "Grand Hall", 1000, 1000, "active", "https://example.com/conference.jpg")
            {
                Id = 3
            },
            new Event("Networking Event", "Networking event for professionals in tech", DateOnly.FromDateTime(DateTime.Now.AddDays(20)),  TimeOnly.Parse("18:00"), "City Center", 200, 200, "active", "https://example.com/networking.jpg")
            {
                Id = 4
            },
            new Event("Food Festival", "A celebration of food from around the world", DateOnly.FromDateTime(DateTime.Now.AddDays(15)),  TimeOnly.Parse("12:00"), "City Park", 300, 300, "active", "https://example.com/foodfestival.jpg")
            {
                Id = 5
            }
        );
    }
}