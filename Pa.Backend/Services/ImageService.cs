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

        public async Task AddNewImage(ImageDbModel image)
        {
            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();
        }

        public async Task CreateImageMetric(Guid image_id, CreateMetricsRequest request)
        {
            var dbItem = new MetricDbModel()
            {
                id = Guid.NewGuid(),
                image_id = image_id,
                healthy_percent = request.healthy_percent,
                unhealthy_percent = request.unhealthy_percent,
                index_type = request.index_Type
            };
            await _context.Metrics.AddAsync(dbItem);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteImage(Guid id)
        {
            var image = await _context.Images.FindAsync(id);

            if (image != null)
            {
                _context.Images.Remove(image);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<GetImageResponse> GetImageById(Guid id)
        {
            var image = await _context.Images.FindAsync(id);
            if (image != null)
            {
                var metrics_list = _context.Metrics.Where(metric => metric.image_id == image.id).ToList();
                var metrics_dto_list = metrics_list.Select(metric_entity => new CreateMetricsRequest
                {
                    healthy_percent = metric_entity.healthy_percent,
                    unhealthy_percent = metric_entity.unhealthy_percent,
                    index_Type = metric_entity.index_type
                }).ToList();

                var response = new GetImageResponse()
                {
                    id = image.id,
                    image_name = image.file_name,
                    is_analyzed = image.is_analyzed,
                    is_processed = image.is_processed,
                    metrics = metrics_dto_list
                };

                return response;
            }

            return null;
        }

        public Task UpdateImage(Guid id, UpdateImageRequest request)
        {
            throw new NotImplementedException();
        }
    }
}