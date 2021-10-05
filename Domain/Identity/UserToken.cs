using Microsoft.AspNetCore.Identity;
using System;

namespace MyProject.Domain.Identity
{
    public class UserToken : IdentityUserToken<Guid>, IEntity
    {
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
