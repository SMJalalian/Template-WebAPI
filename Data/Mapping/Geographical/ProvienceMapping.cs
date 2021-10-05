using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Domain.Geographical;

namespace MyProject.Data.Mapping.Geographical
{
    class ProvienceMapping : IEntityTypeConfiguration<Provience>
    {
        public void Configure(EntityTypeBuilder<Provience> builder)
        {
            builder.ToTable("Geo_Proviences");

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Country)
                .WithMany(c => c.Proviences)
                .HasForeignKey(p => p.CountryId)
                .OnDelete(DeleteBehavior.NoAction);
            ;
        }
    }
}
