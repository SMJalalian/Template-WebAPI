using Microsoft.EntityFrameworkCore;
using MyProject.Data.Mapping.Geographical;
using MyProject.Data.Mapping.Identity;

namespace MyProject.Data
{
    public static class CustomMappings
    {
        public static void AddCustomDataMapping(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityMapping());
            modelBuilder.ApplyConfiguration(new CountryMapping());
            modelBuilder.ApplyConfiguration(new ProvienceMapping());
            modelBuilder.ApplyConfiguration(new AddressMapping());
            modelBuilder.ApplyConfiguration(new RoleClaimMapping());
            modelBuilder.ApplyConfiguration(new RoleMapping());
            modelBuilder.ApplyConfiguration(new UserClaimMapping());
            modelBuilder.ApplyConfiguration(new UserLoginMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new UserRoleMapping());
            modelBuilder.ApplyConfiguration(new UserTokenMapping());
        }
    }
}


