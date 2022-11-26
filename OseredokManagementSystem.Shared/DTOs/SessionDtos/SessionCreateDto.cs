namespace OseredokManagementSystem.Shared.DTOs.SessionDtos
{
    public class SessionCreateDto
    {
        public DateTime SessionDate { get; set; }

        public int ClientId { get; set; }

        public int CoachId { get; set; }

        public int SessionStatusId { get; set; }

        public int GymId { get; set; }
    }
}