using System.ComponentModel.DataAnnotations;

namespace EventsAPI.DTOs
{
    public class ReservationDTO
    {
        [Required(ErrorMessage = "the Status is required")]
        public required string Status { get; set; }

        [Required(ErrorMessage = "the user Id is required")]
        public required int UserId { get; set; }

        [Required(ErrorMessage = "the Event Id is required")]
        public required int EventId { get; set; }
    }
}