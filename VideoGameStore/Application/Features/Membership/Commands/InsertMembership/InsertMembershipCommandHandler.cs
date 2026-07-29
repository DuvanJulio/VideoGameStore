using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.Membership.Commands.InsertMembership
{
    public class InsertMembershipCommandHandler : IRequestHandler<InsertMembershipCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;

        public InsertMembershipCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(InsertMembershipCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var membership = new MembershipEntity
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                IdPlatform = request.IdPlatform,
                IdMembershipType = request.IdMembershipType,
                IdDeliveryType = request.IdDeliveryType
            };

            await _unitOfWork.MembershipRepository.AddAsync(membership);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}
