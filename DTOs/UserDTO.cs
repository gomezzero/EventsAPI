using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsAPI.DTOs
{
    public class UserDTO
    {
        [Required(ErrorMessage = "the Name is required")]
        [MaxLength(20, ErrorMessage = "Name must be 10 characters or less")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "the Address is required")]
        [EmailAddress]
        [MaxLength(30, ErrorMessage = "Address must be 30 characters or less")]
        public required string Address { get; set; }

        [Required(ErrorMessage = "the Password is required")]
        [MaxLength(30, ErrorMessage = "Password must be 30 characters or less")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "the Role is required")]
        public bool Role { get; set; }
    }
}