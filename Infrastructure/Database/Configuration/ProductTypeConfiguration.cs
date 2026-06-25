using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Infrastructure.Database.Configuration
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductTypeEntity>
    {
        public void Configure(EntityTypeBuilder<ProductTypeEntity> builder)
        {
            builder.ToTable("product_type");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at");
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
        }
    }
}