using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.AccountType.Queries.GetAccountTypesById
{
    public class GetAccountTypesByIdQueryHandler : IRequestHandler<GetAccountTypesByIdQuery, AccountTypeEntity>
    {
        private readonly IUnitOfWork _uniOfWork;

        public GetAccountTypesByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
        }

        public async Task<AccountTypeEntity> Handle(GetAccountTypesByIdQuery request, CancellationToken cancellationToken)
        {
            var accountType = await _uniOfWork.AccountTypeRepository.GetByIdAsync(request.Id);

            if (accountType is null)
                throw new NotFoundException(nameof(AccountTypeEntity), request.Id);

            return accountType;
        }
    }
}