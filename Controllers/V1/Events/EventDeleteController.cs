using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EventsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace EventsAPI.Controllers.V1.Events
{
    [Route("api/v1/events")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("events")]
    public class EventDeleteController(IEvent @event) : EventController(@event)
    {
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a event by ID",
            Description = "Removes the specified event from the system."
        )]
        [SwaggerResponse(204, "The event was successfully deleted")]
        [SwaggerResponse(404, "If the event with the specified ID is not found")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var exist = await _event.CheckExistence(id);

            if (!exist)
            {
                return NotFound($"El Evento N° {id} no existe en la base de datos");
            }

            await _event.Delete(id);
            return Ok($"El Evento N°{id} fue eliminado");
        }
    }
}