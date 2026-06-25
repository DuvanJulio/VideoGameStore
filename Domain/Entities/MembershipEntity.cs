namespace VideoGameStore.Domain.Entities
{
    public class MembershipEntity : BaseEntity
    {
        public long IdProduct { get; set; }

        public short IdPlatform { get; set; }

        public short IdMembershipType { get; set; }
    }
}
