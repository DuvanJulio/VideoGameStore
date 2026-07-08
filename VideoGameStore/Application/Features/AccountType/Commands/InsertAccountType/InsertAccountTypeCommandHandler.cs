using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.AccountType.Commands.InsertAccountType
{
    public class InsertAccountTypeCommandHandler : IRequestHandler<InsertAccountTypeCommand, bool>
    {
        public readonly IUnitOfWork _uniOfWork;

        public InsertAccountTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
        }

        public async Task<bool> Handle(InsertAccountTypeCommand request, CancellationToken cancellationToken)
        {
            var accountType = new AccountTypeEntity
            {
                Name = request.Name
            };

            await _uniOfWork.AccountTypeRepository.AddAsync(accountType);
            await _uniOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }

    
}