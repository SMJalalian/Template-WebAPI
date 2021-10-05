using MyProject.Domain.Geographical;
using MyProject.Domain.Identity;
using System;

namespace MyProject.Domain.Identity
{
    public class Address : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? ProvienceId { get; set; }
        public Guid? CityId { get; set; }
        public string Mobile { get; set; }
        public string LandLine { get; set; }
        public string Receiver { get; set; }
        public string PostalAddress { get; set; }
        public string PostalCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }


        public virtual User User { get; set; }
        public virtual Country Country { get; set; }
        public virtual Provience Provience { get; set; }
        public virtual City City { get; set; }
    }
}
