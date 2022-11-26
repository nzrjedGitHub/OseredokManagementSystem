using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OseredokManagementSystem.Server.Core;
using OseredokManagementSystem.Server.Core.Models;
using OseredokManagementSystem.Server.Infrastructure.Interfaces;
using OseredokManagementSystem.Shared.DTOs.AdminDtos;

namespace OseredokManagementSystem.Server.Infrastructure.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _ctx;
        private readonly IMapper _mapper;

        public AdminRepository(AppDbContext context, IMapper mapper)
        {
            _ctx = context;
            _mapper = mapper;
        }

        public async Task<AdminReadDto> GetAdminByIdAsync(int adminId)
        {
            return _mapper.Map<AdminReadDto>(await _ctx.Admins
                .Include(admin => admin.User)
                .FirstOrDefaultAsync(admin => admin.Id == adminId));
        }

        public async Task<AdminReadDto> GetAdminByPhoneNumberAsync(string userPn)
        {
            return _mapper.Map<AdminReadDto>(await _ctx.Admins
                .Include(admin => admin.User)
                .FirstOrDefaultAsync(admin => admin.User.PhoneNumber == userPn));
        }

        public async Task<IEnumerable<AdminReadDto>> GetAdminsAsync()
        {
            return _mapper.Map<IEnumerable<AdminReadDto>>(await _ctx.Admins
                .Include(admin => admin.User)
                .ToListAsync());
        }

        public async Task<IEnumerable<AdminReadDto>> GetAdminsByFirstNameAsync(string adminFn)
        {
            return _mapper.Map<IEnumerable<AdminReadDto>>(await _ctx.Admins
                .Include(admin => admin.User)
                .Where(admin => admin.User.FirstName == adminFn)
                .ToListAsync());
        }

        public async Task<IEnumerable<AdminReadDto>> GetAdminsByLastNameAsync(string adminLn)
        {
            return _mapper.Map<IEnumerable<AdminReadDto>>(await _ctx.Admins
                .Include(admin => admin.User)
                .Where(admin => admin.User.LastName == adminLn)
                .ToListAsync());
        }

        public async Task<IEnumerable<AdminReadDto>> GetAdminsByGymIdAsync(int gymId)
        {
            return _mapper.Map<IEnumerable<AdminReadDto>>(await _ctx.Admins
                .Include(admin => admin.User)
                .Where(admin => admin.Gym.Id == gymId)
                .ToListAsync());
        }

        public async Task<AdminReadDto> UpdateAdminAsync(AdminUpdateDto adminUpdateDto)
        {
            var admin = await _ctx.Admins.FindAsync(adminUpdateDto.Id);

            admin.Salary = adminUpdateDto.Salary;

            admin.GymId = adminUpdateDto.GymId;

            await _ctx.SaveChangesAsync();

            return _mapper.Map<AdminReadDto>(admin);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var temp = _ctx.Admins.Find(id);

            if (temp != null)
            {
                _ctx.Remove(temp);
            }
            await _ctx.SaveChangesAsync();

            return 200;
        }

        public async Task<int> CreateAsync(AdminCreateDto adminCreateDto)
        {
            var admin = _mapper.Map<Admin>(adminCreateDto);

            await _ctx.Admins.AddAsync(admin);
            await _ctx.SaveChangesAsync();

            return admin.Id;
        }
    }
}