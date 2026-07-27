using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.MembershipType.Queries.GetMembershipTypeById
{
    public class GetMembershipTypeByIdQuery : IRequest<MembershipTypeEntity>
    {
        public long Id { get; set; }
    }
}
