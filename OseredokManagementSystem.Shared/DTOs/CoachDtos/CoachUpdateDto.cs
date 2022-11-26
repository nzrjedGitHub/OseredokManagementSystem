namespace OseredokManagementSystem.Shared.DTOs.CoachDtos
{
    public class CoachUpdateDto
    {
        public int Id { get; set; }

        public decimal PercentagePerSession { get; set; }

        public int GymId { get; set; }
    }
}