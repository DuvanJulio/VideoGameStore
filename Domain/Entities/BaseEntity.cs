namespace VideoGameStore.Domain.Entities
{
    public class BaseEntity
    {
        public long Id { get; protected set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
