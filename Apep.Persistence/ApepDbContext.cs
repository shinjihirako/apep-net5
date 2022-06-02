using Apep.Domain.Common;
using Apep.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Apep.Persistence
{
    public class ApepDbContext : DbContext
    {
        public ApepDbContext(DbContextOptions<ApepDbContext> options)
       : base(options)
        {
        }

        public DbSet<MediaItem> mediaItems { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApepDbContext).Assembly);


            //seed data
            modelBuilder.Entity<MediaItem>().HasData(new MediaItem
            {
                Id = Guid.NewGuid(),
                Name = "Bruce Wayne",
                Tag = "Batman",
            }); ;

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
