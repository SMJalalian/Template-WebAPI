using Microsoft.AspNetCore.Identity;
using System;

namespace MyProject.Domain.Identity
{
    public class RoleClaim : IdentityRoleClaim<Guid>, IEntity
    {
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
