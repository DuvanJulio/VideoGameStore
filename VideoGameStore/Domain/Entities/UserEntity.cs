namespace VideoGameStore.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public long IdRole { get; set; }

        public RoleEntity? Role { get; private set; }

        public ICollection<OrderEntity> Order { get; private set; } = [];
    }
}