using Microsoft.EntityFrameworkCore;
using Pa.Backend.Contracts;
using Pa.Backend.Dal;
using Pa.Backend.Interfaces;
using Pa.Backend.Models;

namespace Pa.Backend.Services
{
    public class ImageService : IImageService
    {
        private PaContext _context;

        public ImageService(PaContext context)
        {
            _context = context;
        }

        public async Task AddNewImageAsync(ImageDbModel image)
        {
            var session = _context.Sessions.Find(image.session_id);
            if (session != null)
            {
                await _context.Images.AddAsync(image);
                session.number_of_images += 1;
                await _context.SaveChangesAsync();
                return;
            }
            throw new NullReferenceException();
        }

        public async Task CreateImageMetricAsync(Guid image_id, CreateMetricsRequest request)
        {
            var image = await this._context.Images.FindAsync(image_id);
            var session = await this._context.Sessions.FindAsync(image.session_id);
            var dbItem = new MetricDbModel()
            {
                id = Guid.NewGuid(),
                image_id = image_id,
                healthy_percent = request.healthy_percent,
                unhealthy_percent = request.unhealthy_percent,
                index_type = request.index,
                image_path = request.image_path
            };

            await _context.Metrics.AddAsync(dbItem);
            image.is_analyzed = true;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteImageAsync(Guid id)
        {
            var image = await _context.Images.FindAsync(id);

            if (image != null)
            {
                _context.Images.Remove(image);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ImageResponse> GetImageByIdAsync(Guid id)
        {
            var imageEntity = await _context.Images.FindAsync(id);
            if (imageEntity?.file_path != null)
            {
                var image = File.OpenRead(imageEntity.file_path);
                return new ImageResponse() { Image = image };
            }

            throw new ArgumentNullException("Image does not exist");
        }

        public async Task<ImageResponse> GetAnalyzedImageByIdAsync(Guid id)
        {
            var metricEntity = await _context.Metrics.FindAsync(id);
            if (metricEntity?.image_path != null)
            {
                var image = File.OpenRead(metricEntity.image_path);
                return new ImageResponse() { Image = image };
            }

            throw new ArgumentNullException("Image does not exist");
        }

        // public async Task<GetImageResponse> GetImageByIdAsync(Guid id)
        // {
        //     var image = await _context.Images.FindAsync(id);
        //     if (image != null)
        //     {
        //         var metrics_list = _context.Metrics.Where(metric => metric.image_id == image.id).ToList();
        //         var metrics_dto_list = metrics_list.Select(metric_entity => new CreateMetricsRequest
        //         {
        //             healthy_percent = metric_entity.healthy_percent,
        //             unhealthy_percent = metric_entity.unhealthy_percent,

        //             index = metric_entity.index_type
        //         }).ToList();

        //         var response = new GetImageResponse()
        //         {
        //             id = image.id,
        //             image_name = image.file_name,
        //             is_analyzed = image.is_analyzed,
        //             is_processed = image.is_processed,
        //             image_rgb_path = image.file_path,
        //             metrics = metrics_dto_list
        //         };

        //         return response;
        //     }

        //     return null;
        // }

        public async Task UpdateImageAsync(Guid id, UpdateImageRequest request)
        {
            var image = await _context.Images.FindAsync(id);
            if (image != null)
            {
                image.is_processed = request.is_processed;
                image.is_analyzed = request.is_analyzed;
                await _context.SaveChangesAsync();
            }
        }
    }
}