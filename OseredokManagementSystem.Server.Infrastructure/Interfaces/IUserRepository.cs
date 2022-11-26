using OseredokManagementSystem.Shared.DTOs.UserDtos;

namespace OseredokManagementSystem.Server.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserFullReadDto>> GetUsersFullAsync();

        Task<IEnumerable<UserFullReadDto>> GetUsersFullByFirstNameAsync(string userFn);

        Task<IEnumerable<UserFullReadDto>> GetUsersFullByLastNameAsync(string userLn);

        Task<IEnumerable<UserFullReadDto>> GetUsersFullByMiddleNameAsync(string userMn);

        Task<IEnumerable<UserFullReadDto>> GetUsersFullByDoBirthAsync(DateTime userDoB);

        Task<IEnumerable<UserFullReadDto>> GetUsersFullByDoRegAsync(DateTime userDoReg);

        Task<UserFullReadDto> GetUserFullByIdAsync(int userId);

        Task<UserFullReadDto> GetUserFullByPhoneNumberAsync(string userPn);

        Task<UserReadDto> UpdateUserAsync(UserUpdateDto userUpdateDto);

        Task<int> DeleteAsync(int id);

        Task<int> CreateAsync(UserCreateDto userCreateDto);
    }
}