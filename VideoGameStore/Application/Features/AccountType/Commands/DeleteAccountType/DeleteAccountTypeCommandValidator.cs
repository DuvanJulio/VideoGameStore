using FluentValidation;
using VideoGameStore.Application.Features.AccountType.Commands.DeleteAccountType;

namespace VideoGameStore.Application.Features.AccountType.Commands
{
    public class DeleteAccountTypeCommandValidator : AbstractValidator<DeleteAccountTypeCommand>
    {
        public DeleteAccountTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}