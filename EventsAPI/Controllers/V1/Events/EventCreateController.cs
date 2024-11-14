using System.Globalization;
using EventsAPI.DTOs;
using EventsAPI.Models;
using EventsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EventsAPI.Controllers.V1.Events
{
    [Route("api/v1/events")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("events")]
    public class EventCreateController(IEvent @event) : EventController(@event)
    {
        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new Event",
            Description = "Adds a new Event to the system with the provided name and description."
        )]
        [SwaggerResponse(201, "The Event was successfully created", typeof(Event))]
        [SwaggerResponse(400, "If the Event data is invalid")]
        public async Task<ActionResult<Event>> Create([FromBody] EventDTO inputEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newEvent = new Event(inputEvent.Name, inputEvent.Description, inputEvent.Date, TimeOnly.Parse(inputEvent.Time), inputEvent.Location, inputEvent.MaxCapacity, inputEvent.AvailableSpots, inputEvent.Status, inputEvent.ImageUrl);

            await _event.Add(newEvent);

            return Ok(newEvent);
        }
    }
}