using FluentValidation;

namespace VideoGameStore.Application.Features.GamePlatform.Commands.UpdateGamePlatform
{
    public class UpdateGamePlatformCommandValidator : AbstractValidator<UpdateGamePlatformCommand>
    {
        public UpdateGamePlatformCommandValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");

            RuleFor(x => x.IdGame)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");

            RuleFor(x => x.IdPlatform)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}
