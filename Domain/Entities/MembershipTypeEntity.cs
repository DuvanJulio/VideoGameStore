namespace VideoGameStore.Domain.Entities
{
    public class MembershipTypeEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<MembershipEntity> Memberships { get; private set; } = [];
    }
}