using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Infrastructure.Database.Configuration
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetailEntity>
    {
        public void Configure(EntityTypeBuilder<OrderDetailEntity> builder)
        {
            builder.ToTable("order_detail");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.IdOrder).HasColumnName("id_order");
            builder.Property(x => x.IdProductVariant).HasColumnName("id_product_variant");
            builder.Property(x => x.IdMembership).HasColumnName("id_membership");
            builder.Property(x => x.Quantity).HasColumnName("quantity");
            builder.Property(x => x.UnitPrice).HasColumnName("unit_price").HasColumnType("decimal(18,2)");
            builder.Property(x => x.IsActive).HasColumnName("is_active");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at");
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");

            builder.HasOne(x => x.Order)
                   .WithMany(x => x.OrderDetails)
                   .HasForeignKey(x => x.IdOrder);

            // relaciones opcionales (nullable)
            builder.HasOne(x => x.ProductVariant)
                   .WithMany(x => x.OrderDetails)
                   .HasForeignKey(x => x.IdProductVariant)
                   .IsRequired(false); // ← nullable

            builder.HasOne(x => x.Membership)
                   .WithMany(x => x.OrderDetails)
                   .HasForeignKey(x => x.IdMembership)
                   .IsRequired(false); // ← nullable
        }
    }
}