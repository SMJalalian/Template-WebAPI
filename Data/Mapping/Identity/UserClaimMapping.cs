using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Domain.Identity;

namespace MyProject.Data.Mapping.Identity
{
    class UserClaimMapping : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.ToTable("Idn_UserClaims");

            builder.HasKey(u => u.Id);
        }
    }
}
