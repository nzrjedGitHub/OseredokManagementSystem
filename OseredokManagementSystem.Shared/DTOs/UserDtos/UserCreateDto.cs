namespace OseredokManagementSystem.Shared.DTOs.UserDtos
{
    public class UserCreateDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string ProfileImgPath { get; set; }

        public int RoleId { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }
    }
}