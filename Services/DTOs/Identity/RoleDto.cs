using System;

namespace MyProject.Services.DTOs.Identity
{
    public class RoleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class RoleDtoCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
