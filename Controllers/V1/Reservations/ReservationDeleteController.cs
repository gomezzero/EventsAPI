using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EventsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventsAPI.Controllers.V1.Reservations
{
    [Route("api/v1/reservations")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("reservation")]

    public class ReservationDeleteController(IResevation resevation) : ReservationController(resevation)
    {
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var exist = await _reservation.CheckExistence(id);

            if (!exist)
            {
                return NotFound($"La reservacion N° {id} fue eliminada");
            }

            await _reservation.Delete(id);
            return Ok($"La Reservacion N° {id} fue eliminada");
        }
    }
}