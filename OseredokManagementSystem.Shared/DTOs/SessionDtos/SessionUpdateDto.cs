namespace OseredokManagementSystem.Shared.DTOs.SessionDtos
{
    public class SessionUpdateDto
    {
        public int Id { get; set; }

        public DateTime SessionDate { get; set; }

        public int ClientId { get; set; }

        public int CoachId { get; set; }

        public int SessionStatusId { get; set; }
    }
}