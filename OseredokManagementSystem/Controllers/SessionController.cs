using Microsoft.AspNetCore.Mvc;
using OseredokManagementSystem.Server.Infrastructure.Interfaces;
using OseredokManagementSystem.Shared.DTOs.SessionDtos;

namespace OseredokManagementSystem.Controllers
{
    [Route("api/sessions")]
    [ApiController]
    public class SessionController
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionController(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        [HttpGet]
        [Route("GetSessions")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SessionReadDto>))]
        public async Task<IEnumerable<SessionReadDto>> GetSessions()
        {
            return await _sessionRepository.GetSessionsAsync();
        }

        [HttpGet]
        [Route("GetSessionsByGymId/{gymId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SessionReadDto>))]
        public async Task<IEnumerable<SessionReadDto>> GetSessionsByGymId(int gymId)
        {
            return await _sessionRepository.GetSessionsByGymIdAsync(gymId);
        }

        [HttpGet]
        [Route("GetSessionById/{sessionId}")]
        [ProducesResponseType(200, Type = typeof(SessionReadDto))]
        public async Task<SessionReadDto> GetSessionById(int sessionId)
        {
            return await _sessionRepository.GetSessionByIdAsync(sessionId);
        }

        [HttpGet]
        [Route("GetSessionsByClientId/{clientId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SessionReadDto>))]
        public async Task<IEnumerable<SessionReadDto>> GetSessionsByClientId(int clientId)
        {
            return await _sessionRepository.GetSessionsByClientIdAsync(clientId);
        }

        [HttpGet]
        [Route("GetSessionsByCoachId/{coachId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SessionReadDto>))]
        public async Task<IEnumerable<SessionReadDto>> GetSessionsByCoachId(int coachId)
        {
            return await _sessionRepository.GetSessionsByCoachIdAsync(coachId);
        }

        [HttpPut]
        [Route("UpdateSession")]
        public async Task<SessionReadDto> UpdateSession(SessionUpdateDto sessionUpdateDto)
        {
            return await _sessionRepository.UpdateSessionAsync(sessionUpdateDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _sessionRepository.DeleteAsync(id);
        }

        [HttpPost]
        public async Task<int> CreateAsync(SessionCreateDto sessionCreateDto)
        {
            return await _sessionRepository.CreateAsync(sessionCreateDto);
        }
    }
}