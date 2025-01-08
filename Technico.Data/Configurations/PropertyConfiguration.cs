using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Technico.Data.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_Property_Id");

            builder.ToTable("Property");

            builder.HasIndex(e => e.PropertyId)
                .IsUnique();

            builder.Property(e => e.PropertyId)
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
