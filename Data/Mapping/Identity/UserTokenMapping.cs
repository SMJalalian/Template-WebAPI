using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Domain.Identity;

namespace MyProject.Data.Mapping.Identity
{
    class UserTokenMapping : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable("Idn_UserTokens");
        }
    }
}
