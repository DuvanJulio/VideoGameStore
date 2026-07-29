using FluentValidation;

namespace VideoGameStore.Application.Features.Membership.Commands.DeleteMembership
{
    public class DeleteMembershipCommandValidator : AbstractValidator<DeleteMembershipCommand>
    {
        public DeleteMembershipCommandValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}
