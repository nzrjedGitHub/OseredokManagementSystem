namespace OseredokManagementSystem.Shared.DTOs.CoachDtos
{
    public class CoachCreateDto
    {
        public int UserId { get; set; }

        public decimal PercentagePerSession { get; set; }

        public int GymId { get; set; }
    }
}