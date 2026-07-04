using FluentValidation;

namespace VideoGameStore.Application.Features.Game.Commands.InsertGame
{
    public class InsertGameCommandValidator : AbstractValidator<InsertGameCommand>
    {
        public InsertGameCommandValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                .NotEmpty().WithMessage("{PropertyName} no puede estar en blanco")
                .MaximumLength(200).WithMessage("{PropertyName} excedio el limite maximo de 200 caracteres");

            RuleFor(x => x.Description)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                .NotEmpty().WithMessage("{PropertyName} no puede estar en blanco")
                .MaximumLength(500).WithMessage("{PropertyName} excedio el limite maximo de 500 caracteres");
        }
    }
}
