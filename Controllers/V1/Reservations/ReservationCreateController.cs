using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EventsAPI.DTOs;
using EventsAPI.Models;
using EventsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventsAPI.Controllers.V1.Reservations
{
    [Route("api/v1/event")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("reservation")]
    [Route("[controller]")]
    public class ReservationCreateController(IResevation resevation) : ReservationController(resevation)
    {
        [HttpPost]

        public async Task<ActionResult<Reservation>> Create([FromBody] ReservationDTO inputReservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newReservation = new Reservation(inputReservation.Status, inputReservation.EventId, inputReservation.EventId);
            await _reservation.Add(newReservation);

            return Ok(newReservation);
        }
    }
}