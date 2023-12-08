using Microsoft.AspNetCore.Mvc;
using Pa.Backend.Contracts;
using Pa.Backend.Interfaces;
using Pa.Backend.Models;
using Serilog;

namespace Pa.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService sessionService;
        public SessionsController(ISessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSession([FromBody] CreateSessionRequest sessionRequest)
        {
            var sessionId = await this.sessionService.CreateSessionAsync(sessionRequest);
            return Ok(sessionId);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateSessionPath(Guid id, [FromBody] UpdateSessionPathRequest request)
        {
            await this.sessionService.UpdateSessionPathAsync(id, request.SessionPath);
            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetSessions()
        {
            var sessions = await this.sessionService.GetSessionsAsync();
            return Ok(sessions);
        }

        [HttpGet("metric/{id:Guid}")]
        public async Task<IActionResult> GetSessionMetrics(Guid id)
        {
            var metrics = await this.sessionService.GetSessionMetricsAsync(id);
            return Ok(metrics);
        }


        [HttpGet("images/{id:Guid}")]
        public async Task<IActionResult> GetSessionImages(Guid id)
        {
            // var images = this.sessionService.GetSessionImagesAsync(id, sessionImageParameters.PageNumber, sessionImageParameters.PageSize);
            var images = await this.sessionService.GetSessionImages(id);

            return Ok(images);
        }
    }
}