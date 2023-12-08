using Pa.Backend.Contracts;

namespace Pa.Backend.Interfaces
{
    public interface ISessionService
    {
        Task<Guid> CreateSessionAsync(CreateSessionRequest request);
        Task<List<GetSessionResponse>> GetSessionsAsync();
        Task<GetSessionMetricResponse> GetSessionMetricsAsync(Guid sessionId);
        Task<List<GetImageResponse>> GetSessionImagesAsync(Guid sessionId, int page, int pageSize);

        Task UpdateSessionPathAsync(Guid id, string path);

        Task<List<GetImageResponse>> GetSessionImages(Guid sessionId);
    }
}