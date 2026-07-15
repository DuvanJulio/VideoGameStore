namespace VideoGameStore.Domain.Entities
{
    public class RoleEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<UserEntity> User { get; private set; } = [];
    }
}