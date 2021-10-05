using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProject.Domain.Geographical;
using MyProject.Domain.Identity;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject.Data
{
    public class ApplicationDBContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();
                AddedEntities.ForEach(E =>
                {
                    E.Property("CreatedOn").CurrentValue = DateTime.Now;
                    E.Property("ModifiedOn").CurrentValue = DateTime.Now;
                });

                var EditedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();
                EditedEntities.ForEach(E =>
                {
                    E.Property("ModifiedOn").CurrentValue = DateTime.Now;
                });

                return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            }
            catch (Exception)
            {
                return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            }
        }
        public override int SaveChanges()
        {
            try
            {
                var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();
                AddedEntities.ForEach(E =>
                {
                    E.Property("CreatedOn").CurrentValue = DateTime.Now;
                    E.Property("ModifiedOn").CurrentValue = DateTime.Now;
                });

                var EditedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();
                EditedEntities.ForEach(E =>
                {
                    E.Property("ModifiedOn").CurrentValue = DateTime.Now;
                });
                return base.SaveChanges();
            }
            catch (Exception)
            {
                return base.SaveChanges();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.AddCustomDataMapping();
        }

        //Identities DBSet
        public virtual DbSet<Address> Idn_Addresses { get; set; }
        public virtual DbSet<City> Idn_Cities { get; set; }
        public virtual DbSet<Country> Idn_Countries { get; set; }
        public virtual DbSet<Provience> Idn_Proviences { get; set; }

    }
}
