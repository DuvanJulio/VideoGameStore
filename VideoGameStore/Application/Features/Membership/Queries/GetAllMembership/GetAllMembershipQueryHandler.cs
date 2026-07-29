using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Membership.Queries.GetAllMembership
{
    public class GetAllMembershipQueryHandler : IRequestHandler<GetAllMembershipQuery, List<MembershipEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMembershipQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<MembershipEntity>> Handle(GetAllMembershipQuery request, CancellationToken cancellationToken)
        {
            var memberships = await _unitOfWork.MembershipRepository.GetAllAsync();

            return memberships.ToList();
        }
    }
}
