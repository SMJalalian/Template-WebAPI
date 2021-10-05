using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Domain.Identity;

namespace MyProject.Data.Mapping.Identity
{
    class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Idn_Roles");

            builder.HasKey(r => r.Id);
        }
    }
}
