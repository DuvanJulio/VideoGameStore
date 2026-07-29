using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.Membership.Commands.UpdateMembership
{
    public class UpdateMembershipCommandHandler : IRequestHandler<UpdateMembershipCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;

        public UpdateMembershipCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(UpdateMembershipCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var membership = await _unitOfWork.MembershipRepository.GetByIdAsync(request.Id, cancellationToken);
            if (membership is null)
                throw new NotFoundException();

            membership.Name = request.Name;
            membership.Price = request.Price;
            membership.Stock = request.Stock;
            membership.IdPlatform = request.IdPlatform;
            membership.IdMembershipType = request.IdMembershipType;
            membership.IdDeliveryType = request.IdDeliveryType;
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return true;
        }
    }
}
