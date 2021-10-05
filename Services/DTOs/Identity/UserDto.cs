using System;

namespace MyProject.Services.DTOs.Identity
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserDtoCreate
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserDtoResetPassword
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
    }

    public class UserDtoChangePassword
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class UserDtoAssignRole
    {
        public Guid UserId { get; set; }
        public string RoleName { get; set; }
    }
}
