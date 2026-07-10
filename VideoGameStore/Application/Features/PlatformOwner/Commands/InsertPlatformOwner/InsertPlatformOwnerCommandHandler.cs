using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.PlatformOwner.Commands.InsertPlatformOwner
{
    public class InsertPlatformOwnerCommandHandler : IRequestHandler<InsertPlatformOwnerCommand, bool>
    {
        public readonly IUnitOfWork _unitOfWork;

        public InsertPlatformOwnerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

         public async Task<bool> Handle(InsertPlatformOwnerCommand request, CancellationToken cancellationToken)
        {
            var platformOwner = new PlatformOwnerEntity
            {
                Name = request.Name
            };

            await _unitOfWork.PlatformOwnerRepository.AddAsync(platformOwner);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}