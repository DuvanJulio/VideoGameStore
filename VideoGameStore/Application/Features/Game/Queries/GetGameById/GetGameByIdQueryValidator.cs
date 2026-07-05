using FluentValidation;

namespace VideoGameStore.Application.Features.Game.Queries.GetGameById
{
    public class GetGameByIdQueryValidator : AbstractValidator<GetGameByIdQuery>
    {
        public GetGameByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}
