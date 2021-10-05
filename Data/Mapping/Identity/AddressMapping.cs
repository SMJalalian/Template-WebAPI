using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Domain.Geographical;
using MyProject.Domain.Identity;

namespace MyProject.Data.Mapping.Identity
{
    class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Idn_Addresses");

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Country>(a => a.Country)
                .WithOne(c => c.Address)
                .HasForeignKey<Address>(a => a.CountryId);
            builder.HasOne<Provience>(a => a.Provience)
                .WithOne(p => p.Address)
                .HasForeignKey<Address>(a => a.ProvienceId);
            builder.HasOne<City>(a => a.City)
                .WithOne(c => c.Address)
                .HasForeignKey<Address>(a => a.CityId);
        }
    }
}