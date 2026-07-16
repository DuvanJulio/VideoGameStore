using FluentValidation;

namespace VideoGameStore.Application.Features.Auth.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
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
            .NotEmpty().WithMessage("{PropertyName} no puede estar en blanco")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$").WithMessage("La {PropertyName} debe contener al menos 8 caracteres, una letra mayúscula, una letra minúscula, un número y un carácter especial (@$!%*?&)");

        RuleFor(x => x.Name)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("{PropertyName} no puede ser nulo")
            .NotEmpty().WithMessage("{PropertyName} no puede estar en blanco")
            .MaximumLength(100).WithMessage("{PropertyName} excedió el límite máximo de 100 caracteres");

        RuleFor(x => x.RoleId)
            .Cascade(CascadeMode.Stop)
            .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
    }
}
