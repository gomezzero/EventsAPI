
namespace EventsAPI.DTOs.Request
{
    public class LoginDTO
    {
        public required string Address { get; set; }
        public required string Password { get; set; }
    }
}