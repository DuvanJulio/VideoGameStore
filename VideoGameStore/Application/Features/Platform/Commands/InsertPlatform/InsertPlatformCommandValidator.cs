using FluentValidation;

namespace VideoGameStore.Application.Features.Platform.Commands.InsertPlatform
{
    public class InsertPlatformCommandValidator : AbstractValidator<InsertPlatformCommand>
    {
        public InsertPlatformCommandValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                .NotEmpty().WithMessage("{PropertyName} no puede estar en blanco")
                .MaximumLength(100).WithMessage("{PropertyName} excedio el limite maximo de 200 caracteres");
        }
    }
}