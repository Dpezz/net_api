using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET api
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Hello World!";
        }
    }
}
