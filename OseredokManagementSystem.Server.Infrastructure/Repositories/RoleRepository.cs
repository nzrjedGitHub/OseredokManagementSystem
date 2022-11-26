using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OseredokManagementSystem.Server.Core;
using OseredokManagementSystem.Server.Infrastructure.Interfaces;
using OseredokManagementSystem.Shared.DTOs.RoleDtos;

namespace OseredokManagementSystem.Server.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _ctx;
        private readonly IMapper _mapper;

        public RoleRepository(AppDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<RoleReadDto> GetRoleByIdAsync(int roleId)
        {
            return _mapper.Map<RoleReadDto>(await _ctx.Roles.FirstOrDefaultAsync(role => role.Id == roleId));
        }

        public async Task<RoleReadDto> GetRoleByNameAsync(string roleName)
        {
            return _mapper.Map<RoleReadDto>(await _ctx.Roles.FirstOrDefaultAsync(role => role.Name == roleName));
        }

        public async Task<IEnumerable<RoleReadDto>> GetRolesAsync()
        {
            return _mapper.Map<IEnumerable<RoleReadDto>>(await _ctx.Roles.ToListAsync());
        }
    }
}