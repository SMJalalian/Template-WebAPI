using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Domain.Geographical;
using MyProject.Domain.Identity;

namespace MyProject.Data.Mapping.Identity
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Idn_Users");

            builder.HasKey(u => u.Id);

            builder.HasOne<Country>(u => u.Country)
                .WithOne(c => c.User)
                .HasForeignKey<User>(u => u.CountryId);
            builder.HasOne<Provience>(u => u.Provience)
                .WithOne(p => p.User)
                .HasForeignKey<User>(u => u.ProvienceId);
            builder.HasOne<City>(u => u.City)
                .WithOne(c => c.User)
                .HasForeignKey<User>(u => u.CityId);
        }
    }
}
