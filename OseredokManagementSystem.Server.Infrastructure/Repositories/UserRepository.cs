using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OseredokManagementSystem.Server.Core;
using OseredokManagementSystem.Server.Core.Models;
using OseredokManagementSystem.Server.Infrastructure.Interfaces;
using OseredokManagementSystem.Shared.DTOs.UserDtos;

namespace OseredokManagementSystem.Server.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _ctx;
        private readonly IMapper _mapper;

        public UserRepository(AppDbContext context, IMapper mapper)
        {
            _ctx = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserFullReadDto>> GetUsersFullAsync()
        {
            return _mapper.Map<IEnumerable<UserFullReadDto>>(await _ctx.Users
                .Include(user => user.Role)
                .ToListAsync());
        }

        public async Task<UserFullReadDto> GetUserFullByIdAsync(int userId)
        {
            return _mapper.Map<UserFullReadDto>(await _ctx.Users
                .Include(user => user.Role)
                .FirstOrDefaultAsync(user => user.Id == userId));
        }

        public async Task<UserFullReadDto> GetUserFullByPhoneNumberAsync(string userPn)
        {
            return _mapper.Map<UserFullReadDto>(await _ctx.Users
                .Include(user => user.Role)
                .FirstOrDefaultAsync(user => user.PhoneNumber == userPn));
        }

        public async Task<IEnumerable<UserFullReadDto>> GetUsersFullByDoBirthAsync(DateTime userDoB)
        {
            return _mapper.Map<IEnumerable<UserFullReadDto>>(await _ctx.Users
                .Include(user => user.Role)
                .Where(user => user.DateOfBirth == userDoB)
                .ToListAsync());
        }

        public async Task<IEnumerable<UserFullReadDto>> GetUsersFullByDoRegAsync(DateTime userDoReg)
        {
            return _mapper.Map<IEnumerable<UserFullReadDto>>(await _ctx.Users
                .Include(user => user.Role)
                .Where(user => user.RegDate == userDoReg)
                .ToListAsync());
        }

        public async Task<IEnumerable<UserFullReadDto>> GetUsersFullByFirstNameAsync(string userFn)
        {
            return _mapper.Map<IEnumerable<UserFullReadDto>>(await _ctx.Users
                .Include(user => user.Role)
                .Where(user => user.FirstName == userFn)
                .ToListAsync());
        }

        public async Task<IEnumerable<UserFullReadDto>> GetUsersFullByLastNameAsync(string userLn)
        {
            return _mapper.Map<IEnumerable<UserFullReadDto>>(await _ctx.Users
                .Include(user => user.Role)
                .Where(user => user.LastName == userLn)
                .ToListAsync());
        }

        public async Task<IEnumerable<UserFullReadDto>> GetUsersFullByMiddleNameAsync(string userMn)
        {
            return _mapper.Map<IEnumerable<UserFullReadDto>>(await _ctx.Users
                .Include(user => user.Role)
                .Where(user => user.MiddleName == userMn)
                .ToListAsync());
        }

        public async Task<UserReadDto> UpdateUserAsync(UserUpdateDto userUpdateDto)
        {
            var user = await _ctx.Users.FindAsync(userUpdateDto.Id);

            user.FirstName = userUpdateDto.FirstName;

            user.LastName = userUpdateDto.LastName;

            user.MiddleName = userUpdateDto.MiddleName;

            user.DateOfBirth = userUpdateDto.DateOfBirth;

            user.RegDate = userUpdateDto.RegDate;

            user.ProfileImgPath = userUpdateDto.ProfileImgPath;

            user.PhoneNumber = userUpdateDto.PhoneNumber;

            await _ctx.SaveChangesAsync();

            return _mapper.Map<UserReadDto>(user);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var temp = _ctx.Users.Find(id);

            if (temp != null)
            {
                _ctx.Remove(temp);
            }
            await _ctx.SaveChangesAsync();

            return 200;
        }

        public async Task<int> CreateAsync(UserCreateDto userCreateDto)
        {
            var user = _mapper.Map<User>(userCreateDto);
            user.RegDate = DateTime.Now;

            await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
            return user.Id;
        }
    }
}