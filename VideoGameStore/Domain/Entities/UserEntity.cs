namespace VideoGameStore.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public long IdRol { get; set; }

        public RolEntity? Rol { get; private set; }

        public ICollection<OrderEntity> Order { get; private set; } = [];
    }
}