using FluentValidation;

namespace VideoGameStore.Application.Features.GamePlatform.Commands.InsertGamePlatform
{
    public class InsertGamePlatformCommandValidator : AbstractValidator<InsertGamePlatformCommand>
    {
        public InsertGamePlatformCommandValidator()
        {
            RuleFor(x => x.IdGame)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");

            RuleFor(x => x.IdPlatform)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}
