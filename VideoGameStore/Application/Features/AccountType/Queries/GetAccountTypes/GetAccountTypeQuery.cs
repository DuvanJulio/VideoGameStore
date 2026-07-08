using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.AccountType.Queries.GetAccountTypes
{
    public class GetAccountTypeQuery : IRequest<List<AccountTypeEntity>>
    {
    }
}
