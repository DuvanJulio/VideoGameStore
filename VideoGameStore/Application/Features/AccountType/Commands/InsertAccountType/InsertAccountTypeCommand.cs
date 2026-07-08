using MediatR;

namespace VideoGameStore.Application.Features.AccountType.Commands.InsertAccountType
{
    public class InsertAccountTypeCommand : IRequest<bool>
    {
        public string Name { get; set; } = string.Empty;
    }
}