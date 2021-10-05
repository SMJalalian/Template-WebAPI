using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Domain.Geographical;

namespace MyProject.Data.Mapping.Geographical
{
    class CountryMapping : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Geo_Countries");

            builder.HasKey(c => c.Id);
        }
    }
}
