using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EventsAPI.Models;
using EventsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace EventsAPI.Controllers.V1.Events
{
    [Route("api/v1/event")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("event")]
    public class EventGetController(IEvent @event) : EventController(@event)
    {

        [HttpGet]
        [SwaggerOperation(
            Summary = "Retrieves all Event",
            Description = "Returns a list of all Event in the system."
        )]
        [SwaggerResponse(200, "A list of Event", typeof(IEnumerable<Event>))]
        public async Task<ActionResult<IEnumerable<Event>>> GetAll()
        {
            var Event = await _event.GetAll();
            return Ok(Event);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Retrieves a Event by ID",
            Description = "Returns the Event details for the specified ID."
        )]
        [SwaggerResponse(200, "The Event with the specified ID", typeof(Event))]
        [SwaggerResponse(404, "If the Event with the specified ID is not found")]
        public async Task<ActionResult<Event>> GetById([FromRoute] int id)
        {
            var @event = await _event.GetById(id);

            if (@event == null)
            {
                return NotFound();
            }
            return @event;
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<Event>> GetByStatus([FromRoute] string status)
        {
            var @event = await _event.GetByStatus(status);

            if (@event == null)
            {
                return NotFound();
            }
            return Ok(@event);
        }
    }
}