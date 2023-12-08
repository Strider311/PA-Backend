using Microsoft.EntityFrameworkCore;
using Pa.Backend.Contracts;
using Pa.Backend.Dal;
using Pa.Backend.Interfaces;
using Pa.Backend.Models;

namespace Pa.Backend.Services
{
    public class SessionService : ISessionService
    {
        private PaContext _context;
        public SessionService(PaContext context)
        {
            this._context = context;
        }

        public async Task UpdateSessionPathAsync(Guid id, string path)
        {
            var session = await this._context.Sessions.FindAsync(id);
            if (session != null)
            {
                session.path = path;
                await this._context.SaveChangesAsync();
            }
        }

        public async Task<Guid> CreateSessionAsync(CreateSessionRequest request)
        {
            var sessionId = Guid.NewGuid();
            var sessionDbModel = new SessionDbModel()
            {
                dt_created = DateTime.UtcNow,
                lst_modified = DateTime.UtcNow,
                id = sessionId,
                session_name = request.SessionName
            };

            await _context.Sessions.AddAsync(sessionDbModel);

            await _context.SaveChangesAsync();
            return sessionId;
        }

        public async Task<List<GetImageResponse>> GetSessionImagesAsync(Guid sessionId, int page, int pageSize)
        {
            var imageList = _context.Images.Where(image => image.session_id == sessionId);
            var skip = (page - 1) * pageSize;
            var pageList = await imageList.Skip(skip).Take(pageSize).ToListAsync();
            var toReturn = new List<GetImageResponse>();

            foreach (var img in pageList)
            {

                var metrics_list = _context.Metrics.Where(metric => metric.image_id == img.id).ToList();
                var metrics_dto_list = metrics_list.Select(metric_entity => new GetMetricsRequest
                {
                    healthy_percent = metric_entity.healthy_percent,
                    unhealthy_percent = metric_entity.unhealthy_percent,
                    index = metric_entity.index_type,
                    id = metric_entity.id
                }).ToList();

                var entry = new GetImageResponse()
                {
                    id = img.id,
                    image_name = img.file_name,
                    is_analyzed = img.is_analyzed,
                    is_processed = img.is_processed,
                    metrics = metrics_dto_list,
                    image_rgb_path = img.file_path
                };

                toReturn.Add(entry);
            }
            return toReturn;
        }

        public async Task<GetSessionMetricResponse> GetSessionMetricsAsync(Guid sessionId)
        {
            var session = await _context.Sessions.FindAsync(sessionId);
            if (session != null)
            {

                var response = new GetSessionMetricResponse()
                {
                    DateCreated = session.dt_created,
                    TotalHealthyPercent = session.healthy_percent,
                    TotalUnhealthyPercent = session.unhealthy_percent,
                };

                return response;
            }

            throw new NullReferenceException();
        }

        public async Task<List<GetSessionResponse>> GetSessionsAsync()
        {
            var sessions = _context.Sessions.AsEnumerable();
            var response = new List<GetSessionResponse>();
            foreach (var sesh in sessions)
            {
                var entry = new GetSessionResponse()
                {
                    DateCreated = sesh.dt_created,
                    NoOfImages = sesh.number_of_images,
                    id = sesh.id,
                    SessionName = sesh.session_name,
                };

                response.Add(entry);
            }

            return response;
        }

        public async Task<List<GetImageResponse>> GetSessionImages(Guid sessionId)
        {
            var images = await _context.Images.Where(image => image.session_id == sessionId).ToListAsync();
            var toReturn = new List<GetImageResponse>();
            foreach (var img in images)
            {
                var metrics_list = await _context.Metrics.Where(metric => metric.image_id == img.id).ToListAsync();
                var metrics_dto_list = metrics_list.Select(metric_entity => new GetMetricsRequest
                {
                    healthy_percent = metric_entity.healthy_percent,
                    unhealthy_percent = metric_entity.unhealthy_percent,
                    index = metric_entity.index_type,
                    id = metric_entity.id
                }).ToList();


                var entry = new GetImageResponse()
                {
                    id = img.id,
                    image_name = img.file_name,
                    is_analyzed = img.is_analyzed,
                    is_processed = img.is_processed,
                    metrics = metrics_dto_list,
                    image_rgb_path = img.file_path
                };

                toReturn.Add(entry);
            }

            return toReturn;
        }
    }
}