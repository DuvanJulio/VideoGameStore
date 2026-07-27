using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.MembershipType.Commands.UpdateMembershipType
{
    public class UpdateMembershipTypeCommandHandler : IRequestHandler<UpdateMembershipTypeCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;

        public UpdateMembershipTypeCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(UpdateMembershipTypeCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var membershipType = await _unitOfWork.MembershipTypeRepository.GetByIdAsync(request.Id, cancellationToken);
            if (membershipType is null)
                throw new NotFoundException();

            membershipType.Name = request.Name;
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return true;
        }
    }
}
