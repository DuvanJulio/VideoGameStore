using FluentValidation;

namespace VideoGameStore.Application.Features.Membership.Queries.GetMembershipById
{
    public class GetMembershipByIdQueryValidator : AbstractValidator<GetMembershipByIdQuery>
    {
        public GetMembershipByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}
