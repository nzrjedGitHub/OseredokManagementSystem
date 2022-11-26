using OseredokManagementSystem.Shared.DTOs.SessionStatusDtos;

namespace OseredokManagementSystem.Server.Infrastructure.Interfaces
{
    public interface ISessionStatusRepository
    {
        Task<IEnumerable<SessionStatusReadDto>> GetSessionStatusesAsync();

        Task<SessionStatusReadDto> GetSessionStatusByIdAsync(int sessionStatusId);
    }
}