using Microsoft.AspNetCore.Mvc;
using OseredokManagementSystem.Server.Infrastructure.Interfaces;
using OseredokManagementSystem.Shared.DTOs.AdminDtos;

namespace OseredokManagementSystem.Controllers
{
    [Route("api/admins")]
    [ApiController]
    public class AdminController
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet]
        [Route("GetAdmins")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AdminReadDto>))]
        public async Task<IEnumerable<AdminReadDto>> GetAdmins()
        {
            return await _adminRepository.GetAdminsAsync();
        }

        [HttpGet]
        [Route("GetAdminsByGymId/{gymId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AdminReadDto>))]
        public async Task<IEnumerable<AdminReadDto>> GetAdminsByGymId(int gymId)
        {
            return await _adminRepository.GetAdminsByGymIdAsync(gymId);
        }

        [HttpGet]
        [Route("GetAdminsByLastName/{adminLn}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AdminReadDto>))]
        public async Task<IEnumerable<AdminReadDto>> GetAdminsByLastName(string adminLn)
        {
            return await _adminRepository.GetAdminsByLastNameAsync(adminLn);
        }

        [HttpGet]
        [Route("GetAdminsByFirstName/{adminFn}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AdminReadDto>))]
        public async Task<IEnumerable<AdminReadDto>> GetAdminsByFirstName(string adminFn)
        {
            return await _adminRepository.GetAdminsByFirstNameAsync(adminFn);
        }

        [HttpGet]
        [Route("GetAdminById/{adminId}")]
        [ProducesResponseType(200, Type = typeof(AdminReadDto))]
        public async Task<AdminReadDto> GetAdminById(int adminId)
        {
            return await _adminRepository.GetAdminByIdAsync(adminId);
        }

        [HttpGet]
        [Route("GetAdminByPhoneNumber/{adminPn}")]
        [ProducesResponseType(200, Type = typeof(AdminReadDto))]
        public async Task<AdminReadDto> GetAdminByPhoneNumber(string adminPn)
        {
            return await _adminRepository.GetAdminByPhoneNumberAsync(adminPn);
        }

        [HttpPut]
        [Route("UpdateAdmin")]
        public async Task<AdminReadDto> UpdateAdmin(AdminUpdateDto adminUpdateDto)
        {
            return await _adminRepository.UpdateAdminAsync(adminUpdateDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _adminRepository.DeleteAsync(id);
        }

        [HttpPost]
        public async Task<int> CreateAsync(AdminCreateDto adminCreateDto)
        {
            return await _adminRepository.CreateAsync(adminCreateDto);
        }
    }
}