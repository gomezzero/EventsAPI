using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EventsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventsAPI.Controllers.V1.Users
{
    [Route("api/v1/users")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("users")]
    public class UserDeleteController(IUser user) : UserController(user)
    {
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var exist = await _user.CheckExistence(id);

            if (!exist)
            {
                return NotFound($"El Usuario N° {id} no existe en la base de datos");
            }

            await _user.Delete(id);
            return Ok($"El Usuario N° {id} fue eliminado");
        }
    }
}