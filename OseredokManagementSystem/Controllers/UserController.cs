using Microsoft.AspNetCore.Mvc;
using OseredokManagementSystem.Server.Infrastructure.Interfaces;
using OseredokManagementSystem.Shared.DTOs.UserDtos;

namespace OseredokManagementSystem.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("GetUsersFull")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserFullReadDto>))]
        public async Task<IEnumerable<UserFullReadDto>> GetUsersFull()
        {
            return await _userRepository.GetUsersFullAsync();
        }

        [HttpGet]
        [Route("GetUserFullById/{userId}")]
        [ProducesResponseType(200, Type = typeof(UserFullReadDto))]
        public async Task<UserFullReadDto> GetUserFullById(int userId)
        {
            return await _userRepository.GetUserFullByIdAsync(userId);
        }

        [HttpGet]
        [Route("GetUserFullByPhoneNumber/{userPn}")]
        [ProducesResponseType(200, Type = typeof(UserFullReadDto))]
        public async Task<UserFullReadDto> GetUserFullByPhoneNumber(string userPn)
        {
            return await _userRepository.GetUserFullByPhoneNumberAsync(userPn);
        }

        //[HttpGet]
        //[Route("api/users/GetUsersFullByDoB/{userDoB}")]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<UserFullReadDto>))]
        //public async Task<IEnumerable<UserFullReadDto>> GetUsersFullByDoB(DateTime userDoB)
        //{
        //    return await _userRepository.GetUsersFullByDoBirthAsync(userDoB);
        //}
        //
        //[HttpGet]
        //[Route("api/users/GetUsersFullByDoReg/{userDoReg}")]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<UserFullReadDto>))]
        //public async Task<IEnumerable<UserFullReadDto>> GetUsersFullByDoReg(DateTime userDoReg)
        //{
        //    return await _userRepository.GetUsersFullByDoRegAsync(userDoReg);
        //}

        [HttpGet]
        [Route("GetUsersFullByFirstName/{userFn}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserFullReadDto>))]
        public async Task<IEnumerable<UserFullReadDto>> GetUsersFullByFirstName(string userFn)
        {
            return await _userRepository.GetUsersFullByFirstNameAsync(userFn);
        }

        [HttpGet]
        [Route("GetUsersFullByLastName/{userLn}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserFullReadDto>))]
        public async Task<IEnumerable<UserFullReadDto>> GetUsersFullByLastName(string userLn)
        {
            return await _userRepository.GetUsersFullByLastNameAsync(userLn);
        }

        [HttpGet]
        [Route("GetUsersFullByMiddleName/{userMn}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserFullReadDto>))]
        public async Task<IEnumerable<UserFullReadDto>> GetUsersFullByMiddleName(string userMn)
        {
            return await _userRepository.GetUsersFullByMiddleNameAsync(userMn);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<UserReadDto> UpdateUser(UserUpdateDto userUpdateDto)
        {
            return await _userRepository.UpdateUserAsync(userUpdateDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        [HttpPost]
        public async Task<int> CreateAsync(UserCreateDto userCreateDto)
        {
            return await _userRepository.CreateAsync(userCreateDto);
        }
    }
}