using Microsoft.AspNetCore.Mvc;
using Pa.Backend.Contracts;
using Pa.Backend.Interfaces;
using Pa.Backend.Models;
using Serilog;

namespace Pa.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private IImageService imageService;

        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateImageRequest request)
        {
            try
            {
                var image = MapCreateImageRequest(request);
                this.imageService.AddNewImage(image);
                return Ok(image.id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "failed");
            }
        }

        [HttpPut("/{id:guid}")]
        public IActionResult UpdateImage(Guid id, [FromBody] UpdateImageRequest request)
        {
            try
            {
                this.imageService.UpdateImage(id, request);
                return Ok(id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "failed");
            }
        }

        [HttpPost("/{id:guid}/metric")]
        public IActionResult CreateImageMetric(Guid id, [FromBody] CreateMetricsRequest request)
        {
            try
            {
                this.imageService.CreateImageMetric(id, request);
                return Ok(id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "failed");
            }
        }

        private ImageDbModel MapCreateImageRequest(CreateImageRequest request)
        {
            try
            {
                var image = new ImageDbModel()
                {
                    session_id = request.sessionId,
                    file_name = request.fileName,
                    dt_created = DateTime.UtcNow,
                    lst_modified = DateTime.UtcNow,
                    id = Guid.NewGuid()
                };

                return image;
            }
            catch (Exception ex)
            {
                Log.Error($"Exception encountered: {ex}");
                throw;
            }
        }
    }
}