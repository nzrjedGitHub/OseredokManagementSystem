using Microsoft.AspNetCore.Mvc;
using OseredokManagementSystem.Server.Infrastructure.Interfaces;
using OseredokManagementSystem.Shared.DTOs.GymDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OseredokManagementSystem.Controllers
{
    [Route("api/gyms")]
    [ApiController]
    public class GymController
    {
        private readonly IGymRepository _gymRepository;

        public GymController(IGymRepository gymRepository)
        {
            _gymRepository = gymRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GymReadDto>))]
        public async Task<IEnumerable<GymReadDto>> GetAdmins()
        {
            return await _gymRepository.GetGymsAsync();
        }

        [HttpGet]
        [Route("{gymId}")]
        [ProducesResponseType(200, Type = typeof(GymReadDto))]
        public async Task<GymReadDto> GetAdminById(int gymId)
        {
            return await _gymRepository.GetGymByIdAsync(gymId);
        }

        [HttpPut]
        public async Task<GymReadDto> UpdateAdmin(GymUpdateDto gymUpdateDto)
        {
            return await _gymRepository.UpdateGymAsync(gymUpdateDto);
        }

        [HttpDelete]
        [Route("{gymId}")]
        public async Task<int> DeleteAsync(int gymId)
        {
            return await _gymRepository.DeleteAsync(gymId);
        }

        [HttpPost]
        public async Task<int> CreateAsync(GymCreateDto gymCreateDto)
        {
            return await _gymRepository.CreateAsync(gymCreateDto);
        }
    }
}
