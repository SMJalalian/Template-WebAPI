using MyProject.Domain.Identity;
using System;
using System.Collections.Generic;

namespace MyProject.Domain.Geographical
{
    public class Country : BaseEntity<Guid>
    {
        public string ISO2 { get; set; }
        public string ISO3 { get; set; }
        public string Name { get; set; }
        public string OfficialName { get; set; }
        public int NumCode { get; set; }
        public int PhoneCode { get; set; }
        public Guid? CurrencyId { get; set; }


        public virtual Address Address { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Provience> Proviences { get; set; }
    }
}

