using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.AccountType.Queries.GetAccountTypesById
{
    public class GetAccountTypesByIdQuery : IRequest<AccountTypeEntity>
    {
        public long Id { get; set; }
    }
}