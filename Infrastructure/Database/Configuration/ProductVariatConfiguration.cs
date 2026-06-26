using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Infrastructure.Database.Configuration
{
    public class ProducVariantConfiguration : IEntityTypeConfiguration<ProductVariantEntity>
    {
        public void Configure(EntityTypeBuilder<ProductVariantEntity> builder)
        {
            builder.ToTable("product_variant");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.IdProduct).HasColumnName("id_product");
            builder.Property(x => x.IdAccountType).HasColumnName("id_account_type");
            builder.Property(x => x.Price).HasColumnName("price");
            builder.Property(x => x.Stock).HasColumnName("stock");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at");
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductVariants)
                .HasForeignKey(x => x.IdProduct);

            builder.HasOne(x => x.AccountType)
                .WithMany(x => x.ProductVariants)
                .HasForeignKey(x => x.IdAccountType);
        }
    }
}