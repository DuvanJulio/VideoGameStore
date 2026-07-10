using FluentValidation;

namespace VideoGameStore.Application.Features.PlatformOwner.Commands.InsertPlatformOwner
{
    public class InsertPlatformOwnerCommandValidator : AbstractValidator<InsertPlatformOwnerCommand>
    {
        public InsertPlatformOwnerCommandValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                .NotEmpty().WithMessage("{PropertyName} no puede estar en blanco")
                .MaximumLength(200).WithMessage("{PropertyName} excedio el limite maximo de 200 caracteres");
        }
    }
}