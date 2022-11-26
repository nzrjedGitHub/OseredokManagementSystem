using Microsoft.AspNetCore.Mvc;
using OseredokManagementSystem.Server.Infrastructure.Interfaces;
using OseredokManagementSystem.Shared.DTOs.CoachDtos;

namespace OseredokManagementSystem.Controllers
{
    [Route("api/coaches")]
    [ApiController]
    public class CoachController
    {
        private readonly ICoachRepository _coachRepository;

        public CoachController(ICoachRepository coachRepository)
        {
            _coachRepository = coachRepository;
        }

        [HttpGet]
        [Route("GetCoaches")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CoachReadDto>))]
        public async Task<IEnumerable<CoachReadDto>> GetCoaches()
        {
            return await _coachRepository.GetCoachesAsync();
        }

        [HttpGet]
        [Route("GetCoachesByGymId/{gymId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CoachReadDto>))]
        public async Task<IEnumerable<CoachReadDto>> GetCoachesByGymIdAsync(int gymId)
        {
            return await _coachRepository.GetCoachesByGymIdAsync(gymId);
        }

        [HttpGet]
        [Route("GetCoachesByFirstName/{coachFn}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CoachReadDto>))]
        public async Task<IEnumerable<CoachReadDto>> GetCoachesByFirstName(string coachFn)
        {
            return await _coachRepository.GetCoachesByFirstNameAsync(coachFn);
        }

        [HttpGet]
        [Route("GetCoachesByLastName/{coachLn}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CoachReadDto>))]
        public async Task<IEnumerable<CoachReadDto>> GetCoachesByLastName(string coachLn)
        {
            return await _coachRepository.GetCoachesByLastNameAsync(coachLn);
        }

        [HttpGet]
        [Route("GetCoachById/{coachId}")]
        [ProducesResponseType(200, Type = typeof(CoachReadDto))]
        public async Task<CoachReadDto> GetCoachById(int coachId)
        {
            return await _coachRepository.GetCoachByIdAsync(coachId);
        }

        [HttpGet]
        [Route("GetCoachByPhoneNumber/{coachPn}")]
        [ProducesResponseType(200, Type = typeof(CoachReadDto))]
        public async Task<CoachReadDto> GetCoachByPhoneNumber(string coachPn)
        {
            return await _coachRepository.GetCoachByPhoneNumberAsync(coachPn);
        }

        [HttpPut]
        [Route("UpdateCoach")]
        public async Task<CoachReadDto> UpdateCoach(CoachUpdateDto coachUpdateDto)
        {
            return await _coachRepository.UpdateCoachAsync(coachUpdateDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _coachRepository.DeleteAsync(id);
        }

        [HttpPost]
        public async Task<int> CreateAsync(CoachCreateDto coachCreateDto)
        {
            return await _coachRepository.CreateAsync(coachCreateDto);
        }
    }
}