using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Infrastructure.Database.Configuration
{
    public class GamePlatformConfiguration : IEntityTypeConfiguration<GamePlatformEntity>
    {
        public void Configure(EntityTypeBuilder<GamePlatformEntity> builder)
        {
            builder.ToTable("game_plantform");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.IdGame).HasColumnName("id_game");
            builder.Property(x => x.IdPlatform).HasColumnName("id_platform");
            builder.Property(x => x.IsActive).HasColumnName("is_active");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at");
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");

            
        }
    }
}