using FluentValidation;

namespace VideoGameStore.Application.Features.Platform.Queries.GetPlatformById
{
    public class GetPlatformByIdQueryValidator : AbstractValidator<GetPlatformByIdQuery>
    {
        public GetPlatformByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}
