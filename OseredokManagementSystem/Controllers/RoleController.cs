using Microsoft.AspNetCore.Mvc;
using OseredokManagementSystem.Exceptions;
using OseredokManagementSystem.Server.Infrastructure.Interfaces;
using OseredokManagementSystem.Shared.DTOs.RoleDtos;

namespace OseredokManagementSystem.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RoleReadDto>))]
        public async Task<IEnumerable<RoleReadDto>> GetRoles()
        {
            return await _roleRepository.GetRolesAsync();
        }

        [HttpGet]
        [Route("{roleId}")]
        [ProducesResponseType(200, Type = typeof(RoleReadDto))]
        public async Task<RoleReadDto> GetRoleById(int roleId)
        {
            var role = await _roleRepository.GetRoleByIdAsync(roleId);
            return role;
        }

        [HttpGet]
        [Route("role-name/{roleName}")]
        [ProducesResponseType(200, Type = typeof(RoleReadDto))]
        public async Task<RoleReadDto> GetRoleByName(string roleName)
        {
            return await _roleRepository.GetRoleByNameAsync(roleName);
        }
    }
}