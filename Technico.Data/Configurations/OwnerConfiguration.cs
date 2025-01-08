using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Technico.Core.Entities;

namespace Technico.Data.Configurations
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_Owner_Id");

            builder.ToTable("Owner");

            builder.HasIndex(e => e.VatNumber)
                .IsUnique();

            builder.Property(e => e.VatNumber)
                .HasMaxLength(15);

            builder.Property(e => e.Name)
                .HasMaxLength(50);

            builder.Property(e => e.Surname)
                .HasMaxLength(50);

            builder.Property(e => e.Address)
                .HasMaxLength(300);

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(e => e.Email)
                .HasMaxLength(254);
        }
    }
}
