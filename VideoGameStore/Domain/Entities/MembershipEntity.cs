namespace VideoGameStore.Domain.Entities
{
    public class MembershipEntity : BaseEntity
    {
        public long IdProduct { get; set; }

        public long IdPlatform { get; set; }

        public long IdMembershipType { get; set; }

        public ProductEntity? Products { get; private set; }

        public PlatformEntity? Platform { get; private set; }

        public MembershipTypeEntity? MembershipType { get; private set; }
    }
}
