using FluentValidation;

namespace VideoGameStore.Application.Features.Format.Commands.UpdateFormat
{
    public class UpdateGameCommandValidator : AbstractValidator<UpdateFormatCommand>
    {
        public UpdateGameCommandValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                .NotEmpty().WithMessage("{PropertyName} no puede estar en blanco")
                .MaximumLength(200).WithMessage("{PropertyName} excedio el limite maximo de 200 caracteres");
        }
    }
}