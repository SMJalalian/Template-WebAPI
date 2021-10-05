using MyProject.Domain.Identity;
using System;
using System.Collections.Generic;

namespace MyProject.Domain.Geographical
{
    public class Provience : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public Guid CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual Address Address { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
