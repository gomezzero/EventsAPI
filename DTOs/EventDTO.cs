using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsAPI.DTOs
{
    public class EventDTO
    {
        [Required(ErrorMessage = "the Name is required")]
        [MaxLength(20, ErrorMessage = "Name must be 10 characters or less")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
        public required string Name { get; set; }

        [MaxLength(300, ErrorMessage = "Description must be 300 characters or less")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "the Date is required")]

        public required DateTime Date { get; set; }

        [Required(ErrorMessage = "the Time is required")]

        public required string Time { get; set; }

        [Required(ErrorMessage = "the Location is required")]

        [MaxLength(100, ErrorMessage = "Location must be 10 characters or less")]
        [MinLength(2, ErrorMessage = "Location must be at least 2 characters")]
        public required string Location { get; set; }

        [Required(ErrorMessage = "the MaxCapacity is required")]

        public required int MaxCapacity { get; set; }

        [Required(ErrorMessage = "the AvailableSpots is required")]

        public required int AvailableSpots { get; set; }

        [Required(ErrorMessage = "the Status is required")]

        public required string Status { get; set; }

        public string? ImageUrl { get; set; }

    }
}