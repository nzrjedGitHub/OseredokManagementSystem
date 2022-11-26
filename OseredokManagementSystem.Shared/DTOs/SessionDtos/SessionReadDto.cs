using OseredokManagementSystem.Shared.DTOs.ClientDtos;
using OseredokManagementSystem.Shared.DTOs.CoachDtos;
using OseredokManagementSystem.Shared.DTOs.SessionStatusDtos;

namespace OseredokManagementSystem.Shared.DTOs.SessionDtos
{
    public class SessionReadDto
    {
        public int Id { get; set; }

        public DateTime SessionDate { get; set; }

        public ClientShortReadDto Client { get; set; }

        public CoachReadDto Coach { get; set; }

        public SessionStatusReadDto SessionStatus { get; set; }
    }
}