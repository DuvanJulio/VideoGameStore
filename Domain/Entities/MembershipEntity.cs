namespace VideoGameStore.Domain.Entities
{
    public class MembershipEntity : BaseEntity
    {
        public long IdProduct { get; set; }

        public short IdPlatform { get; set; }

        public short IdMembershipType { get; set; }

        public ProductEntity? Product { get; set; }

        public PlatformEntity? Platform { get; set; }

        public MembershipTypeEntity? MembershipType { get; set; }
    }
}
