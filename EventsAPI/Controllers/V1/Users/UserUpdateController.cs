using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EventsAPI.DTOs;
using EventsAPI.Models;
using EventsAPI.Repositories;
using EventsAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventsAPI.Controllers.V1.Users
{
    [Route("api/v1/users")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("users")]
    public class UserUpdateController(IUser user) : UserController(user)
    {
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserDTO updateUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var checkUser = await _user.CheckExistence(id);

            if (!checkUser)
            {
                return NotFound($"El Usuario N° {id} no existe en la base de datos");
            }

            var user = await _user.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Name = updateUser.Name;
            user.Address = updateUser.Address;
            user.Role = updateUser.Role;

            if (!string.IsNullOrWhiteSpace(updateUser.Password))
            {
                user.Password = PasswordHasher.HashPassword(updateUser.Password);
            }

            await _user.Update(user);
            return NoContent();
        }
    }
}