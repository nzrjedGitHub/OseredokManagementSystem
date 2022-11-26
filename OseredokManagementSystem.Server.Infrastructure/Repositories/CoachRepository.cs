using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OseredokManagementSystem.Server.Core;
using OseredokManagementSystem.Server.Core.Models;
using OseredokManagementSystem.Server.Infrastructure.Interfaces;
using OseredokManagementSystem.Shared.DTOs.CoachDtos;

namespace OseredokManagementSystem.Server.Infrastructure.Repositories
{
    public class CoachRepository : ICoachRepository
    {
        private readonly AppDbContext _ctx;
        private readonly IMapper _mapper;

        public CoachRepository(AppDbContext context, IMapper mapper)
        {
            _ctx = context;
            _mapper = mapper;
        }

        public async Task<CoachReadDto> GetCoachByIdAsync(int coachId)
        {
            return _mapper.Map<CoachReadDto>(await _ctx.Coaches
                .Include(coach => coach.User)
                .FirstOrDefaultAsync(coach => coach.Id == coachId));
        }

        public async Task<CoachReadDto> GetCoachByPhoneNumberAsync(string coachPn)
        {
            return _mapper.Map<CoachReadDto>(await _ctx.Coaches
                .Include(coach => coach.User)
                .FirstOrDefaultAsync(coach => coach.User.PhoneNumber == coachPn));
        }

        public async Task<IEnumerable<CoachReadDto>> GetCoachesAsync()
        {
            return _mapper.Map<IEnumerable<CoachReadDto>>(await _ctx.Coaches
                .Include(coach => coach.User)
                .ToListAsync());
        }

        public async Task<IEnumerable<CoachReadDto>> GetCoachesByGymIdAsync(int gymId)
        {
            return _mapper.Map<IEnumerable<CoachReadDto>>(await _ctx.Coaches
                .Include(coach => coach.User)
                .Where(coach => coach.Gym.Id == gymId)
                .ToListAsync());
        }

        public async Task<IEnumerable<CoachReadDto>> GetCoachesByFirstNameAsync(string coachFn)
        {
            return _mapper.Map<IEnumerable<CoachReadDto>>(await _ctx.Coaches
                .Include(coach => coach.User)
                .Where(coach => coach.User.FirstName == coachFn)
                .ToListAsync());
        }

        public async Task<IEnumerable<CoachReadDto>> GetCoachesByLastNameAsync(string coachLn)
        {
            return _mapper.Map<IEnumerable<CoachReadDto>>(await _ctx.Coaches
                .Include(coach => coach.User)
                .Where(coach => coach.User.LastName == coachLn)
                .ToListAsync());
        }

        public async Task<CoachReadDto> UpdateCoachAsync(CoachUpdateDto coachUpdateDto)
        {
            var coach = await _ctx.Coaches.FindAsync(coachUpdateDto.Id);

            coach.GymId = coachUpdateDto.GymId;

            coach.PercentagePerSession = coachUpdateDto.PercentagePerSession;

            await _ctx.SaveChangesAsync();

            return _mapper.Map<CoachReadDto>(coach);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var temp = _ctx.Coaches.Find(id);

            if (temp != null)
            {
                _ctx.Remove(temp);
            }
            await _ctx.SaveChangesAsync();

            return 200;
        }

        public async Task<int> CreateAsync(CoachCreateDto coachCreateDto)
        {
            var coach = _mapper.Map<Coach>(coachCreateDto);

            await _ctx.Coaches.AddAsync(coach);
            await _ctx.SaveChangesAsync();

            return coach.Id;
        }
    }
}