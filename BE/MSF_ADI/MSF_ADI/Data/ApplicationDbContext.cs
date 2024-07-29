using Microsoft.EntityFrameworkCore;
using BpkbApi.Models;

namespace BpkbApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bpkb> Bpkbs { get; set; }
        public DbSet<StorageLocation> StorageLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bpkb>()
                .HasKey(b => b.AgreementNumber); // Set AgreementNumber as Primary Key

            modelBuilder.Entity<StorageLocation>()
                .HasKey(s => s.LocationId); // Set LocationId as Primary Key

            base.OnModelCreating(modelBuilder);
        }
    }
}
