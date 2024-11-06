using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace EventsAPI.Models
{
    [Table("events")]
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public required string Name { get; set; }

        [Column("description")]
        [MaxLength(300)]
        public string? Description { get; set; }

        [Column("date")]
        [Required]
        public required DateTime Date { get; set; }

        [Column("time")]
        [Required]
        public required string Time { get; set; }

        [Column("location")]
        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public required string Location { get; set; }

        [Column("max_capacity")]
        [Required]
        public required int MaxCapacity { get; set; }

        [Column("availableSpots")]
        [Required]
        public required int AvailableSpots { get; set; }

        [Column("status")]
        [Required]
        public required string Status { get; set; }
         
        [Column("image_url")]
        public string? ImageUrl { get; set; }

        public Event(string name, string description, DateTime date, string time, string location, int maxCapacity, int availableSpots, string status, string imageUrl)
        {
            Name = name.ToLower().Trim();
            Description = description.ToLower().Trim();
            Date = date;
            Time = time;
            Location = location.ToLower().Trim();
            MaxCapacity = maxCapacity;
            AvailableSpots = availableSpots;
            Status = status.ToLower().Trim();
            ImageUrl = imageUrl;
        }
    }
}