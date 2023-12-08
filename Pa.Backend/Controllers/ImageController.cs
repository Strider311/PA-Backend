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
        public async Task<IActionResult> Create([FromBody] CreateImageRequest request)
        {
            try
            {
                var image = MapCreateImageRequest(request);
                await this.imageService.AddNewImageAsync(image);
                return Ok(image.id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "failed");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetImage(Guid id)
        {
            var image = await imageService.GetImageByIdAsync(id);

            return File(image.Image, "image/jpeg");
        }

        [HttpGet("analyzed/{id:guid}")]
        public async Task<IActionResult> GetAnalyzedImage(Guid id)
        {
            var image = await imageService.GetAnalyzedImageByIdAsync(id);

            return File(image.Image, "image/jpeg");
        }


        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateImage(Guid id, [FromBody] UpdateImageRequest request)
        {
            try
            {
                await this.imageService.UpdateImageAsync(id, request);
                return Ok(id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "failed");
            }
        }

        [HttpPost("metric/{id:guid}")]
        public async Task<IActionResult> CreateImageMetric(Guid id, [FromBody] CreateMetricsRequest request)
        {
            try
            {
                await this.imageService.CreateImageMetricAsync(id, request);
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
                    id = Guid.NewGuid(),
                    file_path = request.filePath
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