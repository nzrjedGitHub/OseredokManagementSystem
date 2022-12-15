using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OseredokManagementSystem.Server.Core;
using OseredokManagementSystem.Server.Core.Models;
using OseredokManagementSystem.Server.Infrastructure.Interfaces;
using OseredokManagementSystem.Shared.DTOs.GymDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OseredokManagementSystem.Server.Infrastructure.Repositories
{
    public class GymRepository : IGymRepository
    {
        private readonly AppDbContext _ctx;
        private readonly IMapper _mapper;
        public GymRepository( AppDbContext context, IMapper mapper)
        {
            _ctx = context;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(GymCreateDto gymCreateDto)
        {
            var gym = _mapper.Map<Gym>(gymCreateDto);

            await _ctx.Gyms.AddAsync(gym);
            await _ctx.SaveChangesAsync();
            return gym.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var temp = _ctx.Gyms.Find(id);

            if (temp != null)
            {
                _ctx.Remove(temp);
            }
            await _ctx.SaveChangesAsync();

            return 200;
        }

        public async Task<GymReadDto> GetGymByIdAsync(int gymId)
        {
            return _mapper.Map<GymReadDto>(await _ctx.Gyms
                .FirstOrDefaultAsync(gym => gym.Id == gymId));
        }

        public async Task<IEnumerable<GymReadDto>> GetGymsAsync()
        {
            return _mapper.Map< IEnumerable<GymReadDto>>(await _ctx.Gyms
                .ToListAsync());
        }

        public async Task<GymReadDto> UpdateGymAsync(GymUpdateDto gymUpdateDto)
        {
            var gym = await _ctx.Gyms.FindAsync(gymUpdateDto.Id);

            gym.Address = gymUpdateDto.Address;
            gym.ClientCapacity = gymUpdateDto.ClientCapacity;

            await _ctx.SaveChangesAsync();

            return _mapper.Map<GymReadDto>(gym);
        }
    }
}
