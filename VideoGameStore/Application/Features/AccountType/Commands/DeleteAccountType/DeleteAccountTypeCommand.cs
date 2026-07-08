using MediatR;

namespace VideoGameStore.Application.Features.AccountType.Commands.DeleteAccountType
{
    public class DeleteAccountTypeCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}