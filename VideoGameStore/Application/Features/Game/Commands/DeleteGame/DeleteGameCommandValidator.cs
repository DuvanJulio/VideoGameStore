using FluentValidation;

namespace VideoGameStore.Application.Features.Game.Commands.DeleteGame
{
    public class DeleteGameValidator : AbstractValidator<DeleteGameCommand>
    {
        public DeleteGameValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}