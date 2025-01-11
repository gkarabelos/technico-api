using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Technico.Core.Entities;

namespace Technico.Data.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_Property_Id");

            builder.ToTable("Property");

            builder.HasIndex(e => e.E9)
                .IsUnique();

            builder.Property(e => e.E9)
                .HasMaxLength(20);

            builder.Property(e => e.Address)
                .HasMaxLength(200);

            builder.HasOne(d => d.Owner)
                .WithMany(p => p.Properties)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Property_Owner");
        }
    }
}
