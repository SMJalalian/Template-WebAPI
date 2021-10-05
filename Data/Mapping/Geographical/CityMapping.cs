using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Domain.Geographical;

namespace MyProject.Data.Mapping.Geographical
{
    class CityMapping : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Geo_Cities");

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Provience)
                .WithMany(p => p.Cities)
                .HasForeignKey(c => c.ProvienceId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
