﻿namespace OseredokManagementSystem.Shared.DTOs.UserDtos
{
    public class UserReadDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string ProfileImgPath { get; set; }

        public string PhoneNumber { get; set; }
    }
}