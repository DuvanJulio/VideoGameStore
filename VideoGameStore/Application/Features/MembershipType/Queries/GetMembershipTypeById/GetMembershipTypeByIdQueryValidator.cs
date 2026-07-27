using FluentValidation;

namespace VideoGameStore.Application.Features.MembershipType.Queries.GetMembershipTypeById
{
    public class GetMembershipTypeByIdQueryValidator : AbstractValidator<GetMembershipTypeByIdQuery>
    {
        public GetMembershipTypeByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}
