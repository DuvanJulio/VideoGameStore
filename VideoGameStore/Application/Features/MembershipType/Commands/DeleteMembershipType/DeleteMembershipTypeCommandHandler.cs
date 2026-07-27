using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.MembershipType.Commands.DeleteMembershipType
{
    public class DeleteMembershipTypeCommandHandler : IRequestHandler<DeleteMembershipTypeCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICurrentUser _currentUser;

        public DeleteMembershipTypeCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;

            _currentUser = currentUser;
        }

        public async Task<bool> Handle(DeleteMembershipTypeCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var membershipType = await _unitOfWork.MembershipTypeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (membershipType is null)
                throw new NotFoundException("");

            membershipType.IsActive = false;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}
