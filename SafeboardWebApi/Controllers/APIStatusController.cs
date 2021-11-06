using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeboardWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class APIStatusController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get() => Ok();
    }
}
