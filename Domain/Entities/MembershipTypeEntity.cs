namespace VideoGameStore.Domain.Entities
{
    public class MembershipTypeEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<MembershipEntity> Memberships { get; set; } = [];
    }
}