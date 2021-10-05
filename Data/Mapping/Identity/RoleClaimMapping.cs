using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Domain.Identity;

namespace MyProject.Data.Mapping.Identity
{
    class RoleClaimMapping : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.ToTable("Idn_RoleClaims");

            builder.HasKey(r => r.Id);
        }
    }
}
