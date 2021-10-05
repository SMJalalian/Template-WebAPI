using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Domain.Identity;

namespace MyProject.Data.Mapping.Identity
{
    class UserLoginMapping : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.ToTable("Idn_UserLogins");
        }
    }
}
