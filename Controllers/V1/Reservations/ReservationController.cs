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
    public class ReservationController(IResevation resevation) : ControllerBase
    {
        protected readonly IResevation _reservation = resevation;
    }
}