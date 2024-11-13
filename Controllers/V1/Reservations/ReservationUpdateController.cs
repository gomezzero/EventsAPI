using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EventsAPI.DTOs;
using EventsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventsAPI.Controllers.V1.Reservations
{
    [Route("api/v1/reservations")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("reservation")]
    public class ReservationUpdateController(IResevation resevation) : ReservationController(resevation)
    {
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ReservationDTO updateReservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        
            var checkReservation = await _reservation.CheckExistence(id);

            if (!checkReservation)
            {
                return NotFound($"la vento N° {id} no existe en la base de datos");
            }

            var reservation = await _reservation.GetById(id);

            if (reservation == null)
            {
                return NotFound();
            }

            reservation.Status = updateReservation.Status;
            reservation.UserId = updateReservation.UserId;
            reservation.EventId = updateReservation.EventId;

            await _reservation.Update(reservation);
            return NoContent();
        }
    }
}