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
        [ProducesResponseType(200, Type = typeof(IEnumerable<SessionReadDto>))]
        public async Task<IEnumerable<SessionReadDto>> GetSessions()
        {
            return await _sessionRepository.GetSessionsAsync();
        }

        [HttpGet]
        [Route("gym/{gymId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SessionReadDto>))]
        public async Task<IEnumerable<SessionReadDto>> GetSessionsByGymId(int gymId)
        {
            return await _sessionRepository.GetSessionsByGymIdAsync(gymId);
        }

        [HttpGet]
        [Route("{sessionId}")]
        [ProducesResponseType(200, Type = typeof(SessionReadDto))]
        public async Task<SessionReadDto> GetSessionById(int sessionId)
        {
            return await _sessionRepository.GetSessionByIdAsync(sessionId);
        }

        [HttpGet]
        [Route("client/{clientId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SessionReadDto>))]
        public async Task<IEnumerable<SessionReadDto>> GetSessionsByClientId(int clientId)
        {
            return await _sessionRepository.GetSessionsByClientIdAsync(clientId);
        }

        [HttpGet]
        [Route("coach/{coachId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SessionReadDto>))]
        public async Task<IEnumerable<SessionReadDto>> GetSessionsByCoachId(int coachId)
        {
            return await _sessionRepository.GetSessionsByCoachIdAsync(coachId);
        }

        [HttpPut]
        public async Task<SessionReadDto> UpdateSession(SessionUpdateDto sessionUpdateDto)
        {
            return await _sessionRepository.UpdateSessionAsync(sessionUpdateDto);
        }

        [HttpDelete]
        [Route("{sessionId}")]
        public async Task<int> DeleteAsync(int sessionId)
        {
            return await _sessionRepository.DeleteAsync(sessionId);
        }

        [HttpPost]
        public async Task<int> CreateAsync(SessionCreateDto sessionCreateDto)
        {
            return await _sessionRepository.CreateAsync(sessionCreateDto);
        }
    }
}