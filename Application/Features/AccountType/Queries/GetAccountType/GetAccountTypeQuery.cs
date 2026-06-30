using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.AccountType.Queries.GetAccountType
{
    public class GetAccountTypeQuery : IRequest<List<AccountTypeEntity>>
    {
    }
}
