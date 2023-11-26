using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pa.Backend.Interfaces;
using Pa.Backend.Models;
using Serilog;

namespace Pa.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {

        public SessionsController()
        {
            Log.Information("Init Session controller");
        }

        [HttpPost("/create")]
        public IActionResult CreateSession()
        {

            return NotFound();
        }

        [HttpGet()]
        public IActionResult GetSessions()
        {
            return NotFound();
        }

        [HttpGet("/metric/{id:Guid}")]
        public IActionResult GetSessionMetrics(Guid id)
        {

            return NotFound();
        }

        [HttpGet("/images")]
        public IActionResult GetSessionImages([FromQuery] SessionImagesParameters sessionImageParameters)
        {
            return NotFound();
        }
    }
}
