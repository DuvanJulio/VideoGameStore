using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.AccountType.Commands.DeleteAccountType
{
    public class DeleteAccountTypeCommandHandler : IRequestHandler<DeleteAccountTypeCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAccountTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteAccountTypeCommand request, CancellationToken cancellationToken)
        {
            var accountType = await _unitOfWork.AccountTypeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (accountType is null)
                throw new NotFoundException(nameof(AccountTypeEntity));

            accountType.IsActive = false;
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}