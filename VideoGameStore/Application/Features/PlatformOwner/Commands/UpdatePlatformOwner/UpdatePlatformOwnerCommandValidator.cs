using FluentValidation;

namespace VideoGameStore.Application.Features.PlatformOwner.Commands.UpdatePlatformOwner
{
    public class UpdatePlatformOwnerCommandValidator : AbstractValidator<UpdatePlatformOwnerCommand>
    {
        public UpdatePlatformOwnerCommandValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                .NotEmpty().WithMessage("{PropertyName} no puede estar en blanco")
                .MaximumLength(200).WithMessage("{PropertyName} excedio el limite maximo de 200 caracteres");
        }
    }
}