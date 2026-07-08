using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;
using VideoGameStore.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace VideoGameStore.Application.Features.AccountType.Commands.UpdateAccountType
{
    public class UpdateAccountTypeCommandHandler : IRequestHandler<UpdateAccountTypeCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAccountTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateAccountTypeCommand request, CancellationToken cancellationToken)
        {
            var accountType = await _unitOfWork.AccountTypeRepository.GetByIdAsync(request.Id);

            if (accountType is null)
                throw new NotFoundException(nameof(AccountTypeEntity), request);

            accountType.Name = request.Name;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}