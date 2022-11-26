using OseredokManagementSystem.Shared.DTOs.CoachDtos;

namespace OseredokManagementSystem.Server.Infrastructure.Interfaces
{
    public interface ICoachRepository
    {
        Task<IEnumerable<CoachReadDto>> GetCoachesAsync();

        Task<IEnumerable<CoachReadDto>> GetCoachesByGymIdAsync(int gymId);

        Task<IEnumerable<CoachReadDto>> GetCoachesByFirstNameAsync(string coachFn);

        Task<IEnumerable<CoachReadDto>> GetCoachesByLastNameAsync(string coachLn);

        Task<CoachReadDto> GetCoachByIdAsync(int coachId);

        Task<CoachReadDto> GetCoachByPhoneNumberAsync(string coachPn);

        Task<CoachReadDto> UpdateCoachAsync(CoachUpdateDto coachUpdateDto);

        Task<int> DeleteAsync(int id);

        Task<int> CreateAsync(CoachCreateDto coachCreateDto);
    }
}