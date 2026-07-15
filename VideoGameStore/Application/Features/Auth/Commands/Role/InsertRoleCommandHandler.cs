using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;
using VideoGameStore.Infrastructure.Repository;

namespace VideoGameStore.Application.Features.Auth.Commands.Role
{
    public class InsertRoleCommandHandler : IRequestHandler<InsertRoleCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public InsertRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(InsertRoleCommand request, CancellationToken cancellationToken)
        {

            var role = new RoleEntity
            {
                Name = request.Name
            };
            await _unitOfWork.RoleRepository.AddAsync(role);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}