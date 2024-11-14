using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EventsAPI.Config;
using EventsAPI.DTOs.Request;
using EventsAPI.Repositories;
using EventsAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventsAPI.Controllers.V1.Auth
{
    [Route("api/v1/auth")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AuthController : ControllerBase
    {
        protected readonly IUser servicios;

        public AuthController(IUser userRepository)
        {
            servicios = userRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO data)
        {
            var user = await servicios.GetByAddress(data.Address);

            if (user == null)
            {
                return BadRequest("El usuario no existe");
            }

            // Verificar la contraseña hasheada
            bool isPasswordValid = PasswordHasher.VerifiPassword(data.Password, user.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Contraseña incorrecta");
            }



            var token = JWT.GenerateJwtToken(user);

            return Ok($"ACA ESTA SU TOKEN: {token}");
        }

    }
}