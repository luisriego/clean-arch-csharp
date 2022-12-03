using CleanArch.Domain;
using CleanArch.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Persistence
{
    public class StreamerDbContext : DbContext
    {
        protected StreamerDbContext(DbContextOptions<StreamerDbContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=SPECTRE-WIN; Initial Catalog=Streamer; Integrated Security=True")
        //        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
        //        .EnableSensitiveDataLogging();
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.Now;
                        entry.Entity.UpdatedBy = "system";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streamer>()
                .HasMany(s => s.Videos)
                .WithOne(v => v.Streamer)
                .HasForeignKey(v => v.StreamerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Video>()
                .HasMany(v => v.Actors)
                .WithMany(a => a.Videos)
                .UsingEntity<VideoActor>(
                    va => va.HasKey(e => new { e.ActorId, e.VideoId })
                );
        }

        public DbSet<Streamer>? Streamers { get; set; }

        public DbSet<Video>? Videos { get; set; }

        public DbSet<Actor>? Actors { get; set; }

        public DbSet<Director>? Directors { get; set; }
    }
}
