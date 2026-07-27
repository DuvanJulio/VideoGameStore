using FluentValidation;

namespace VideoGameStore.Application.Features.MembershipType.Commands.DeleteMembershipType
{
    public class DeleteMembershipTypeCommandValidator : AbstractValidator<DeleteMembershipTypeCommand>
    {
        public DeleteMembershipTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}
