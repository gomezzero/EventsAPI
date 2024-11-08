using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsAPI.Models
{
    [Table("reservations")]
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set;}

        [Column("status")]
        [Required]
        public required string Status { get; set; }

        // forein Key
        [Column("user_id")]
        public required int UserId { get; set; }

        [Column("event_id")]
        public required int EventId { get; set; }

        // conection forein key
        [ForeignKey("UserId")]
        public required User User { get; set; }

        [ForeignKey("EventId")]
        public required Event Event { get; set; }

        public Reservation(string status, int userId, int eventId)
        {
            Status = status.ToLower().Trim();
            UserId = userId;
            EventId = eventId;
        }
    }
}