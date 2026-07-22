using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.Platform.Commands.InsertPlatform
{
    public class InsertPlatformCommandHandler : IRequestHandler<InsertPlatformCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICurrentUser _currentUser;

        public InsertPlatformCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;

            _currentUser = currentUser;
        }

        public async Task<bool> Handle(InsertPlatformCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var platform = new PlatformEntity
            {
                Name = request.Name
            };

            await _unitOfWork.platformRepository.AddAsync(platform);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}