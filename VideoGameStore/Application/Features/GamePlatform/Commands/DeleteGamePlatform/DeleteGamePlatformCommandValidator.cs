using FluentValidation;

namespace VideoGameStore.Application.Features.GamePlatform.Commands.DeleteGamePlatform
{
    public class DeleteGamePlatformCommandValidator : AbstractValidator<DeleteGamePlatformCommand>
    {
        public DeleteGamePlatformCommandValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}
