using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.Membership.Queries.GetMembershipById
{
    public class GetMembershipByIdQueryHandler : IRequestHandler<GetMembershipByIdQuery, MembershipEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMembershipByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MembershipEntity> Handle(GetMembershipByIdQuery request, CancellationToken cancellationToken)
        {
            var membership = await _unitOfWork.MembershipRepository.GetByIdAsync(request.Id);

            if (membership is null)
                throw new NotFoundException();

            return membership;
        }
    }
}
