using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EventsAPI.DTOs;
using EventsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace EventsAPI.Controllers.V1.Events
{
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("events")]
    public class EventUpdateController(IEvent @event) : EventController(@event)
    {
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Updates an existing Event",
            Description = "Updates the Event with the specified ID, if it exists, with the provided new details."
        )]
        [SwaggerResponse(204, "The Event was successfully updated")]
        [SwaggerResponse(400, "If the provided Event data is invalid")]
        [SwaggerResponse(404, "If the Event with the specified ID is not found")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] EventDTO updateEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var checkEvent = await _event.CheckExistence(id);

            if (!checkEvent)
            {
                return NotFound($"la vento N°{id} no existe en la base de datos");
            }

            var @event = await _event.GetById(id);

            if (@event == null)
            {
                return NotFound();
            }

            @event.Name = updateEvent.Name;
            @event.Description = updateEvent.Description;
            @event.Date = updateEvent.Date;
            @event.Time = TimeOnly.Parse(updateEvent.Time);
            @event.Location = updateEvent.Location;
            @event.MaxCapacity = updateEvent.MaxCapacity;
            @event.AvailableSpots = updateEvent.AvailableSpots;
            @event.Status = updateEvent.Status;
            @event.ImageUrl = updateEvent.ImageUrl;

            await _event.Update(@event);
            return NoContent();
        }
    }
}