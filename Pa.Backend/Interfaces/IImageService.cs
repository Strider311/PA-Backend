using Pa.Backend.Contracts;
using Pa.Backend.Models;

namespace Pa.Backend.Interfaces
{
    public interface IImageService
    {
        Task<GetImageResponse> GetImageById(Guid id);

        Task AddNewImage(ImageDbModel image);

        Task DeleteImage(Guid id);

        Task UpdateImage(Guid id, UpdateImageRequest request);

        Task CreateImageMetric(Guid image_id, CreateMetricsRequest request);
    }
}