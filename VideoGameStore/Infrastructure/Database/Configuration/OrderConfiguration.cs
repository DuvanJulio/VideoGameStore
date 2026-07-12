using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Infrastructure.Database.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("order");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.IdUser).HasColumnName("id_user");
            builder.Property(x => x.Total).HasColumnName("total");
            builder.Property(x => x.IsActive).HasColumnName("is_active");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at");
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");

            // mapeo del enum
            builder.Property(x => x.Status)
                   .HasColumnName("status")
                   .HasConversion<string>(); // guarda "Pending", "Completed", "Cancelled"

            builder.HasOne(x => x.User)
                .WithMany(x => x.Order)
                .HasForeignKey(x => x.IdUser);
        }
    }
}