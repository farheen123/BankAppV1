using BankApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        public override int SaveChanges()
        {
            UpdateAuditFields();
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditFields();
            return await base.SaveChangesAsync(cancellationToken);
        }
        private void UpdateAuditFields()
        {
            var entries = ChangeTracker.Entries<AuditableEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.DateModified = DateTime.UtcNow;
                }
            }
        }
        public DbSet<BankCustomer> Customer { get; set; }
    }
}
