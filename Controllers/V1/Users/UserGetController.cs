using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using EventsAPI.Models;
using EventsAPI.Repositories;
using EventsAPI.Controllers.V1.Users;
using Microsoft.AspNetCore.Authorization;

namespace UsersAPI.Controllers.V1.Users
{
    [Route("api/v1/users")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("users")]
    public class UserGetController(IUser user) : UserController(user)
    {

        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(
            Summary = "Retrieves all User",
            Description = "Returns a list of all User in the system."
        )]
        [SwaggerResponse(200, "A list of User", typeof(IEnumerable<User>))]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var user = await _user.GetAll();
            return Ok(user);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(
            Summary = "Retrieves a User by ID",
            Description = "Returns the User details for the specified ID."
        )]
        [SwaggerResponse(200, "The User with the specified ID", typeof(User))]
        [SwaggerResponse(404, "If the User with the specified ID is not found")]
        public async Task<ActionResult<User>> GetById([FromRoute] int id)
        {
            var user = await _user.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

    }
}