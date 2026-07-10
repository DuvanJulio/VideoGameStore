using FluentValidation;
using VideoGameStore.Domain.Entities;


namespace VideoGameStore.Application.Features.PlatformOwner.Queries.GetPlatformOwnerById
{
    public class GetAccountTypeQueryValidator : AbstractValidator<GetPlatformOwnerByIdQuery>
    {
        public GetAccountTypeQueryValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}