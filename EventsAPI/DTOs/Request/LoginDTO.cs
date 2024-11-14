using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsAPI.DTOs.Request
{
    public class LoginDTO
    {
        public required string Address { get; set; }
        public required string Password { get; set; }
    }
}