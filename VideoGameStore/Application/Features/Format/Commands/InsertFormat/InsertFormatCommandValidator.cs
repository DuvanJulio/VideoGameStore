using FluentValidation;

namespace VideoGameStore.Application.Features.Format.Commands.InsertFormat
{
    public class InsertFormatCommandValidator : AbstractValidator<InsertFormatCommand>
    {
        public InsertFormatCommandValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                .NotEmpty().WithMessage("{PropertyName} no puede estar en blanco")
                .MaximumLength(200).WithMessage("{PropertyName} excedio el limite maximo de 200 caracteres");
        }
    }
}