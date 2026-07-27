using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.MembershipType.Queries.GetAllMembershipType
{
    public class GetAllMembershipTypeQueryHandler : IRequestHandler<GetAllMembershipTypeQuery, List<MembershipTypeEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMembershipTypeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<MembershipTypeEntity>> Handle(GetAllMembershipTypeQuery request, CancellationToken cancellationToken)
        {
            var membershipTypes = await _unitOfWork.MembershipTypeRepository.GetAllAsync();

            return membershipTypes.ToList();
        }
    }
}
