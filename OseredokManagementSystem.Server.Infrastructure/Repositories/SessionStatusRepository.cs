using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OseredokManagementSystem.Server.Core;
using OseredokManagementSystem.Server.Infrastructure.Interfaces;
using OseredokManagementSystem.Shared.DTOs.SessionStatusDtos;

namespace OseredokManagementSystem.Server.Infrastructure.Repositories
{
    public class SessionStatusRepository : ISessionStatusRepository
    {
        private readonly AppDbContext _ctx;
        private readonly IMapper _mapper;

        public SessionStatusRepository(AppDbContext context, IMapper mapper)
        {
            _ctx = context;
            _mapper = mapper;
        }

        public async Task<SessionStatusReadDto> GetSessionStatusByIdAsync(int sessionStatusId)
        {
            return _mapper.Map<SessionStatusReadDto>(await _ctx.SessionStatuses
                .FirstOrDefaultAsync(sessionStatus => sessionStatus.Id == sessionStatusId));
        }

        public async Task<IEnumerable<SessionStatusReadDto>> GetSessionStatusesAsync()
        {
            return _mapper.Map<IEnumerable<SessionStatusReadDto>>(await _ctx.SessionStatuses
                .ToListAsync());
        }
    }
}