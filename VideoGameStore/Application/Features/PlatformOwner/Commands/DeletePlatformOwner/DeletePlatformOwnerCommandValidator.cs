using FluentValidation;

namespace VideoGameStore.Application.Features.PlatformOwner.Commands.DeletePlatformOwner
{
    public class DeletePlatformOwnerValidator : AbstractValidator<DeletePlatformOwnerCommand>
    {
        public DeletePlatformOwnerValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}