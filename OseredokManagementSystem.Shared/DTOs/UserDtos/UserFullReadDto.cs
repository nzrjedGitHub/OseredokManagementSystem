using OseredokManagementSystem.Shared.DTOs.RoleDtos;

namespace OseredokManagementSystem.Shared.DTOs.UserDtos
{
    public class UserFullReadDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime RegDate { get; set; }

        public string ProfileImgPath { get; set; }

        public RoleReadDto Role { get; set; }

        public string PhoneNumber { get; set; }
    }
}