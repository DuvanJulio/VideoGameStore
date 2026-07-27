using FluentValidation;

namespace VideoGameStore.Application.Features.MembershipType.Commands.InsertMembershipType
{
    public class InsertMembershipTypeCommandValidator : AbstractValidator<InsertMembershipTypeCommand>
    {
        public InsertMembershipTypeCommandValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                .NotEmpty().WithMessage("{PropertyName} no puede estar en blanco")
                .MaximumLength(100).WithMessage("{PropertyName} excedio el limite maximo de 100 caracteres");
        }
    }
}
