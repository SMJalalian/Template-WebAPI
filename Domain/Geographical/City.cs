using MyProject.Domain.Identity;
using System;

namespace MyProject.Domain.Geographical
{
    public class City : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public Guid ProvienceId { get; set; }


        public virtual Provience Provience { get; set; }
        public virtual Address Address { get; set; }
        public virtual User User { get; set; }

    }
}
