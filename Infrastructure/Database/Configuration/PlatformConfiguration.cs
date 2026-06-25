using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Infrastructure.Database.Configuration
{
    public class PlatformConfiguration : IEntityTypeConfiguration<PlatformEntity>
    {
        public void Configure(EntityTypeBuilder<PlatformEntity> builder)
        {
            builder.ToTable("platform");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.IdPlatformOwner).HasColumnName("id_platform_owner");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at");
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
        }
    }
}