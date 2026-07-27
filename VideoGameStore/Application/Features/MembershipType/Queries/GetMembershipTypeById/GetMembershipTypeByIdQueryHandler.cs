using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.MembershipType.Queries.GetMembershipTypeById
{
    public class GetMembershipTypeByIdQueryHandler : IRequestHandler<GetMembershipTypeByIdQuery, MembershipTypeEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMembershipTypeByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MembershipTypeEntity> Handle(GetMembershipTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var membershipType = await _unitOfWork.MembershipTypeRepository.GetByIdAsync(request.Id);

            if (membershipType is null)
                throw new NotFoundException();

            return membershipType;
        }
    }
}
