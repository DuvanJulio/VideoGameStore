using MediatR;

namespace VideoGameStore.Application.Features.AccountType.Commands.UpdateAccountType
{
    public class UpdateAccountTypeCommand : IRequest<bool>
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}