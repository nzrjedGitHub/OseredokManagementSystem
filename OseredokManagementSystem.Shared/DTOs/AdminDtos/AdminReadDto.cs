using OseredokManagementSystem.Shared.DTOs.UserDtos;

namespace OseredokManagementSystem.Shared.DTOs.AdminDtos
{
    public class AdminReadDto
    {
        public int Id { get; set; }

        public decimal Salary { get; set; }

        public UserReadDto User { get; set; }
    }
}