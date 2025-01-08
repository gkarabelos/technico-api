using Microsoft.EntityFrameworkCore;
using Technico.Data.Configurations;

namespace Technico.Data
{
    public class TechnicoDbContext : DbContext
    {
        public TechnicoDbContext()
        {
        }

        public TechnicoDbContext(DbContextOptions<TechnicoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Owner> Owners { get; set; }

        public virtual DbSet<Property> Properties { get; set; }

        public virtual DbSet<Repair> Repairs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyConfiguration());
            modelBuilder.ApplyConfiguration(new RepairConfiguration());
        }
    }
}
