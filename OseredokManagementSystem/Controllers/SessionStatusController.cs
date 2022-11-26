using Microsoft.AspNetCore.Mvc;
using OseredokManagementSystem.Server.Infrastructure.Interfaces;
using OseredokManagementSystem.Shared.DTOs.SessionStatusDtos;

namespace OseredokManagementSystem.Controllers
{
    [Route("api/sessionStatuses")]
    [ApiController]
    public class SessionStatusController
    {
        private readonly ISessionStatusRepository _sessionStatusRepository;

        public SessionStatusController(ISessionStatusRepository sessionStatusRepository)
        {
            _sessionStatusRepository = sessionStatusRepository;
        }

        [HttpGet]
        [Route("GetSessionStatuses")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SessionStatusReadDto>))]
        public async Task<IEnumerable<SessionStatusReadDto>> GetSessionStatuses()
        {
            return await _sessionStatusRepository.GetSessionStatusesAsync();
        }

        [HttpGet]
        [Route("GetSessionStatusById/{sessionStatusId}")]
        [ProducesResponseType(200, Type = typeof(SessionStatusReadDto))]
        public async Task<SessionStatusReadDto> GetSessionStatusById(int sessionStatusId)
        {
            return await _sessionStatusRepository.GetSessionStatusByIdAsync(sessionStatusId);
        }
    }
}