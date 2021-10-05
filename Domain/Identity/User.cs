using Microsoft.AspNetCore.Identity;
using MyProject.Domain.Geographical;
using MyProject.Shared.Enums;
using System;
using System.Collections.Generic;

namespace MyProject.Domain.Identity
{
    public class User : IdentityUser<Guid>, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderType? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? ProvienceId { get; set; }
        public Guid? CityId { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Country Country { get; set; }
        public virtual Provience Provience { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public User() : base()
        {
        }

        public User(string name) : base(name)
        {

        }
    }
}
