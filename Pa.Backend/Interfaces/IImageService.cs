using Pa.Backend.Contracts;
using Pa.Backend.Models;

namespace Pa.Backend.Interfaces
{
    public interface IImageService
    {
        Task<ImageResponse> GetImageByIdAsync(Guid id);

        Task<ImageResponse> GetAnalyzedImageByIdAsync(Guid id);

        Task AddNewImageAsync(ImageDbModel image);

        Task DeleteImageAsync(Guid id);

        Task UpdateImageAsync(Guid id, UpdateImageRequest request);

        Task CreateImageMetricAsync(Guid image_id, CreateMetricsRequest request);
    }
}