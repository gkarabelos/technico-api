using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Technico.Core.Entities;

namespace Technico.Data.Configurations
{
    public class RepairConfiguration : IEntityTypeConfiguration<Repair>
    {
        public void Configure(EntityTypeBuilder<Repair> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_Repair_Id");

            builder.ToTable("Repair");

            builder.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            builder.Property(e => e.Type)
                .HasMaxLength(50);

            builder.Property(e => e.Cost)
                .HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.Property)
                .WithMany(p => p.Repairs)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Repair_Property");
        }
    }
}
