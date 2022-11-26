using OseredokManagementSystem.Shared.DTOs.SessionDtos;

namespace OseredokManagementSystem.Server.Infrastructure.Interfaces
{
    public interface ISessionRepository
    {
        Task<IEnumerable<SessionReadDto>> GetSessionsAsync();

        Task<IEnumerable<SessionReadDto>> GetSessionsByGymIdAsync(int gymId);

        Task<IEnumerable<SessionReadDto>> GetSessionsByClientIdAsync(int clientId);

        Task<IEnumerable<SessionReadDto>> GetSessionsByCoachIdAsync(int coachId);

        Task<IEnumerable<SessionReadDto>> GetSessionsByStatusIdAsync(int statusId);

        Task<SessionReadDto> GetSessionByIdAsync(int sessionId);

        Task<SessionReadDto> UpdateSessionAsync(SessionUpdateDto sessionUpdateDto);

        Task<int> DeleteAsync(int id);

        Task<int> CreateAsync(SessionCreateDto sessionCreateDto);
    }
}