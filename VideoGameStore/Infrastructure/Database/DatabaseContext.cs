using Microsoft.EntityFrameworkCore;
using Microting.EntityFrameworkCore.MySql.Infrastructure;
using System.Data;
using System.Reflection;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Infrastructure.Utils;

namespace VideoGameStore.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
         private readonly AppEnvironment _env;

        public DatabaseContext(DbContextOptions<DatabaseContext> options, AppEnvironment env) : base(options)
        {
            _env = env;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                _env.DATABASE_STRING_BUILDER.ConnectionString,
                new MariaDbServerVersion(new Version(10, 11, 0)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType, builder =>
                    {
                        builder.HasKey("Id");

                        builder.Property("Id").ValueGeneratedOnAdd();

                        builder.Property("CreatedAt")
                            .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                            .ValueGeneratedOnAdd();

                        builder.Property("UpdatedAt")
                            .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                            .ValueGeneratedOnAddOrUpdate();
                        
                        builder.Property("IsActive")
                            .HasDefaultValue(true)
                            .ValueGeneratedOnAdd();
                    });
                }
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<DeliveryTypeEntity> DeliveryType => Set<DeliveryTypeEntity>();

        public DbSet<GameEntity> Game => Set<GameEntity>();

        public DbSet<GamePlatformEntity> GamePlatform => Set<GamePlatformEntity>();

        public DbSet<MembershipEntity> Membership => Set<MembershipEntity>();

        public DbSet<MembershipTypeEntity> MembershipTypes => Set<MembershipTypeEntity>();

        public DbSet<PlatformEntity> Platform => Set<PlatformEntity>();

        public DbSet<ProductEntity> Product => Set<ProductEntity>();

        public DbSet<ProductTypeEntity> ProductType => Set<ProductTypeEntity>();

        public DbSet<ProductVariantEntity> ProductVariant => Set<ProductVariantEntity>();   
    }
}