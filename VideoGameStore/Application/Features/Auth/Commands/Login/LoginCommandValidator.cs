using FluentValidation;

namespace VideoGameStore.Application.Features.Auth.Commands.Login.Validators
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                .NotEmpty().WithMessage("{PropertyName} no puede estar en blanco")
                .MaximumLength(100).WithMessage("{PropertyName} excedió el límite máximo de 100 caracteres")
                .EmailAddress().WithMessage("El formato de {PropertyName} es inválido");

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                .NotEmpty().WithMessage("{PropertyName} no puede estar en blanco");
        }
    }
}