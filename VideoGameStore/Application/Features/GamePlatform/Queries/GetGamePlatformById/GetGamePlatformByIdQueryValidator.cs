using FluentValidation;

namespace VideoGameStore.Application.Features.GamePlatform.Queries.GetGamePlatformById
{
    public class GetGamePlatformByIdQueryValidator : AbstractValidator<GetGamePlatformByIdQuery>
    {
        public GetGamePlatformByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}
