using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.AccountType.Queries.GetAccountTypes
{
    public class GetAccountTypeQueryHandler : IRequestHandler<GetAccountTypeQuery, List<AccountTypeEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAccountTypeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<AccountTypeEntity>> Handle(GetAccountTypeQuery request, CancellationToken cancellationToken)
        {
            var acountTypes = await _unitOfWork.AccountTypeRepository.GetAllAsync();

            return acountTypes.ToList();
        }
    }
}
