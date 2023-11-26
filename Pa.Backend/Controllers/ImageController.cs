using System.Xml;
using Microsoft.AspNetCore.Http;
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
        private IImageRepository imageRepository;

        public ImageController(IImageRepository imageRepo)
        {
            this.imageRepository = imageRepo;
        }

        [HttpPost("/")]
        public IActionResult Create(ImageContract contract)
        {
            try
            {
                var image = MapImage(contract);
                this.imageRepository.AddNewImage(image);
                return Ok(image.id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "failed");
            }
        }

        private ImageDbModel MapImage(ImageContract contract)
        {
            try
            {
                var image = new ImageDbModel()
                {
                    session_id = contract.sessionId,
                    fileName = contract.fileName,
                    dtCreated = DateTime.UtcNow,
                    lstModified = DateTime.UtcNow,
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
