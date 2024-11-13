using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EventsAPI.DTOs;
using EventsAPI.Models;
using EventsAPI.Repositories;
using EventsAPI.Utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventsAPI.Controllers.V1.Users
{
    [Route("api/v1/users")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("users")]
    public class UserCreateController(IUser user) : UserController(user)
    {
        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] UserDTO inputUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hasPassword = PasswordHasher.HashPassword(inputUser.Password);

            var newUser = new User(inputUser.Name, inputUser.Address, hasPassword, inputUser.Role);

            await _user.Add(newUser);

            return Ok(newUser);
        }
    }
}