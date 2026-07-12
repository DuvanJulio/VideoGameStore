namespace VideoGameStore.Domain.Entities
{
    public class RolEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<UserEntity> User { get; private set; } = [];
    }
}