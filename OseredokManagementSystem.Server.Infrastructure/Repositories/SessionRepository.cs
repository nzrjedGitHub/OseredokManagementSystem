using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OseredokManagementSystem.Server.Core;
using OseredokManagementSystem.Server.Core.Models;
using OseredokManagementSystem.Server.Infrastructure.Interfaces;
using OseredokManagementSystem.Shared.DTOs.SessionDtos;

namespace OseredokManagementSystem.Server.Infrastructure.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly AppDbContext _ctx;
        private readonly IMapper _mapper;

        public SessionRepository(AppDbContext appDbContext, IMapper mapper)
        {
            _ctx = appDbContext;
            _mapper = mapper;
        }

        public async Task<SessionReadDto> GetSessionByIdAsync(int sessionId)
        {
            return _mapper.Map<SessionReadDto>(await _ctx.Sessions
                .Include(session => session.Coach).ThenInclude(coach => coach.User)
                .Include(session => session.Client).ThenInclude(client => client.User)
                .Include(session => session.Client).ThenInclude(client => client.ClientPayment)
                .Include(session => session.SessionStatus)
                .FirstOrDefaultAsync(session => session.Id == sessionId));
        }

        public async Task<IEnumerable<SessionReadDto>> GetSessionsAsync()
        {
            return _mapper.Map<IEnumerable<SessionReadDto>>(await _ctx.Sessions
                .Include(session => session.Coach).ThenInclude(coach => coach.User)
                .Include(session => session.Client).ThenInclude(client => client.User)
                .Include(session => session.Client).ThenInclude(client => client.ClientPayment)
                .Include(session => session.SessionStatus)
                .ToListAsync());
        }

        public async Task<IEnumerable<SessionReadDto>> GetSessionsByClientIdAsync(int clientId)
        {
            return _mapper.Map<IEnumerable<SessionReadDto>>(await _ctx.Sessions
                .Include(session => session.Coach).ThenInclude(coach => coach.User)
                .Include(session => session.Client).ThenInclude(client => client.User)
                .Include(session => session.Client).ThenInclude(client => client.ClientPayment)
                .Include(session => session.SessionStatus)
                .Where(session => session.Client.Id == clientId)
                .ToListAsync());
        }

        public async Task<IEnumerable<SessionReadDto>> GetSessionsByCoachIdAsync(int coachId)
        {
            return _mapper.Map<IEnumerable<SessionReadDto>>(await _ctx.Sessions
                .Include(session => session.Coach).ThenInclude(coach => coach.User)
                .Include(session => session.Client).ThenInclude(client => client.User)
                .Include(session => session.Client).ThenInclude(client => client.ClientPayment)
                .Include(session => session.SessionStatus)
                .Where(session => session.Coach.Id == coachId)
                .ToListAsync());
        }

        public async Task<IEnumerable<SessionReadDto>> GetSessionsByGymIdAsync(int gymId)
        {
            return _mapper.Map<IEnumerable<SessionReadDto>>(await _ctx.Sessions
                .Include(session => session.Coach).ThenInclude(coach => coach.User)
                .Include(session => session.Client).ThenInclude(client => client.User)
                .Include(session => session.Client).ThenInclude(client => client.ClientPayment)
                .Include(session => session.SessionStatus)
                .Where(session => session.Gym.Id == gymId)
                .ToListAsync());
        }

        public async Task<IEnumerable<SessionReadDto>> GetSessionsByStatusIdAsync(int statusId)
        {
            return _mapper.Map<IEnumerable<SessionReadDto>>(await _ctx.Sessions
                .Include(session => session.Coach).ThenInclude(coach => coach.User)
                .Include(session => session.Client).ThenInclude(client => client.User)
                .Include(session => session.Client).ThenInclude(client => client.ClientPayment)
                .Include(session => session.SessionStatus)
                .Where(session => session.SessionStatus.Id == statusId)
                .ToListAsync());
        }

        public async Task<SessionReadDto> UpdateSessionAsync(SessionUpdateDto sessionUpdateDto)
        {
            var session = await _ctx.Sessions
                .Include(session => session.Coach).ThenInclude(coach => coach.User)
                .Include(session => session.Client).ThenInclude(client => client.User)
                .Include(session => session.Client).ThenInclude(client => client.ClientPayment)
                .Include(session => session.SessionStatus)
                .FirstOrDefaultAsync(session => session.Id == sessionUpdateDto.Id);

            session.SessionStatusId = sessionUpdateDto.SessionStatusId;

            session.CoachId = sessionUpdateDto.CoachId;

            session.ClientId = sessionUpdateDto.ClientId;

            session.SessionDate = sessionUpdateDto.SessionDate;

            await _ctx.SaveChangesAsync();

            return _mapper.Map<SessionReadDto>(session);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var temp = _ctx.Sessions.Find(id);

            if (temp != null)
            {
                _ctx.Remove(temp);
            }
            await _ctx.SaveChangesAsync();

            return 200;
        }

        public async Task<int> CreateAsync(SessionCreateDto sessionCreateDto)
        {
            var sesion = _mapper.Map<Session>(sessionCreateDto);

            await _ctx.Sessions.AddAsync(sesion);
            await _ctx.SaveChangesAsync();

            return sesion.Id;
        }
    }
}