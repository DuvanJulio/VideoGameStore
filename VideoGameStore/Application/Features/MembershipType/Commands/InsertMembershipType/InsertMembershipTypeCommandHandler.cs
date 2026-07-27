using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.MembershipType.Commands.InsertMembershipType
{
    public class InsertMembershipTypeCommandHandler : IRequestHandler<InsertMembershipTypeCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICurrentUser _currentUser;

        public InsertMembershipTypeCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;

            _currentUser = currentUser;
        }

        public async Task<bool> Handle(InsertMembershipTypeCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var membershipType = new MembershipTypeEntity
            {
                Name = request.Name
            };

            await _unitOfWork.MembershipTypeRepository.AddAsync(membershipType);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}
