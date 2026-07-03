using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Infrastructure.Database.Configuration
{
    public class MembershipConfiguration : IEntityTypeConfiguration<MembershipEntity>
    {
        public void Configure(EntityTypeBuilder<MembershipEntity> builder)
        {
            builder.ToTable("membership");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.IdProduct).HasColumnName("id_product");
            builder.Property(x => x.IdPlatform).HasColumnName("id_platform");
            builder.Property(x => x.IdMembershipType).HasColumnName("id_membership_type");
            builder.Property(x => x.IsActive).HasColumnName("is_active");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at");
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");

            builder.HasOne(x => x.Products)
                .WithMany(x => x.Memberships)
                .HasForeignKey(x => x.IdPlatform);

            builder.HasOne(x => x.Platform)
                .WithMany(x => x.Memberships)
                .HasForeignKey(x => x.IdPlatform);

            builder.HasOne(x => x.MembershipType)
                .WithMany(x => x.Memberships)
                .HasForeignKey(x => x.IdMembershipType);
        }
    }
}