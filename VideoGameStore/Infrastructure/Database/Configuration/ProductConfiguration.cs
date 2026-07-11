using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Infrastructure.Database.Configuration
{
    public class ProducConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.IdProductType).HasColumnName("id_product_type");
            builder.Property(x => x.IdGamePlatform).HasColumnName("id_game_platform");
            builder.Property(x => x.IsActive).HasColumnName("is_active");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at");
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");

            builder.HasOne(x => x.GamePlatform)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.IdGamePlatform);

            builder.HasOne(x => x.ProductType)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.IdProductType);
        }
    }
}