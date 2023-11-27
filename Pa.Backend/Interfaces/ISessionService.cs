using Pa.Backend.Contracts;

namespace Pa.Backend.Interfaces
{
    public interface ISessionService
    {
        Task CreateSession(CreateSessionRequest request);

        Task<List<GetSessionResponse>> GetSessions();
        
    }
}