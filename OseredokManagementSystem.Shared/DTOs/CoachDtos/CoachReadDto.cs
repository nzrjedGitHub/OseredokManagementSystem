using OseredokManagementSystem.Shared.DTOs.UserDtos;

namespace OseredokManagementSystem.Shared.DTOs.CoachDtos
{
    public class CoachReadDto
    {
        public int Id { get; set; }

        public decimal PercentagePerSession { get; set; }

        public UserReadDto User { get; set; }
    }
}