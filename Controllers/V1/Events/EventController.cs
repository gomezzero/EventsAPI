using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EventsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventsAPI.Controllers.V1.Events
{
    [Route("api/v1/[controller]")]
    public class EventController(IEvent @event) : ControllerBase
    {
        protected readonly IEvent _event = @event;
    }
}