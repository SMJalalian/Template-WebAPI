using Microsoft.AspNetCore.Identity;
using System;

namespace MyProject.Domain.Identity
{
    public class Role : IdentityRole<Guid>, IEntity
    {
        public Role()
        {

        }

        public Role(string name) : base(name)
        {

        }

        public Role(string name, string description) : base(name)
        {
            Description = description;
        }

        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
