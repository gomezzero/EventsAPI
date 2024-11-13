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
using EventsAPI.Controllers.V1.Reservations;

namespace ReservationsAPI.Controllers.V1.Reservations
{
    [Route("api/v1/reservations")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("reservation")]
    public class ReservationGetController(IResevation resevation) : ReservationController(resevation)
    {
        [HttpGet("all")]
        [SwaggerOperation(
            Summary = "Retrieves all Reservation",
            Description = "Returns a list of all Reservation in the system."
        )]
        [SwaggerResponse(200, "A list of Reservation", typeof(IEnumerable<Reservation>))]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAll()
        {
            var Reservation = await _reservation.GetAll();
            return Ok(Reservation);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Retrieves a Reservation by ID",
            Description = "Returns the Reservation details for the specified ID."
        )]
        [SwaggerResponse(200, "The Reservation with the specified ID", typeof(Reservation))]
        [SwaggerResponse(404, "If the Reservation with the specified ID is not found")]
        public async Task<ActionResult<Reservation>> GetById([FromRoute] int id)
        {
            var reservation = await _reservation.GetById(id);

            if (reservation == null)
            {
                return NotFound();
            }
            return reservation;
        }

        [HttpGet("name_event/{eventName}")]
        public async Task<ActionResult<Reservation>> GetByNameEvent([FromRoute] string eventName)
        {
            var reservation = await _reservation.GetByNameEvent(eventName);

            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }
    }
}