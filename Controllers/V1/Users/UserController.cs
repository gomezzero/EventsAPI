using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EventsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventsAPI.Controllers.V1.Users
{
    [Route("[controller]")]
    public class UserController(IUser user) : ControllerBase
    {
        protected readonly IUser _user = user;
    }
}