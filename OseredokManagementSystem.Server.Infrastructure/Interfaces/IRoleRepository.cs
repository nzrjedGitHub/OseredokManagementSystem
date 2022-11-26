using OseredokManagementSystem.Shared.DTOs.RoleDtos;

namespace OseredokManagementSystem.Server.Infrastructure.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<RoleReadDto>> GetRolesAsync();

        Task<RoleReadDto> GetRoleByIdAsync(int roleId);

        Task<RoleReadDto> GetRoleByNameAsync(string roleName);
    }
}