using FluentValidation;

namespace VideoGameStore.Application.Features.MembershipType.Commands.UpdateMembershipType
{
    public class UpdateMembershipTypeCommandValidator : AbstractValidator<UpdateMembershipTypeCommand>
    {
        public UpdateMembershipTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                .NotEmpty().WithMessage("{PropertyName} no puede estar en blanco")
                .MaximumLength(100).WithMessage("{PropertyName} excedio el limite maximo de 100 caracteres");
        }
    }
}
