using OseredokManagementSystem.Shared.DTOs.AdminDtos;

namespace OseredokManagementSystem.Server.Infrastructure.Interfaces
{
    public interface IAdminRepository
    {
        Task<IEnumerable<AdminReadDto>> GetAdminsAsync();

        Task<IEnumerable<AdminReadDto>> GetAdminsByGymIdAsync(int gymId);

        Task<IEnumerable<AdminReadDto>> GetAdminsByLastNameAsync(string adminLn);

        Task<IEnumerable<AdminReadDto>> GetAdminsByFirstNameAsync(string adminFn);

        Task<AdminReadDto> GetAdminByIdAsync(int adminId);

        Task<AdminReadDto> GetAdminByPhoneNumberAsync(string userPn);

        Task<AdminReadDto> UpdateAdminAsync(AdminUpdateDto adminUpdateDto);

        Task<int> DeleteAsync(int id);

        Task<int> CreateAsync(AdminCreateDto adminCreateDto);
    }
}