using FluentValidation;

namespace VideoGameStore.Application.Features.Game.Commands.SoftDeleteGame
{
    public class SoftDeleteGamevalidator : AbstractValidator<SoftDeleteGameCommand>
    {
        public SoftDeleteGamevalidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}