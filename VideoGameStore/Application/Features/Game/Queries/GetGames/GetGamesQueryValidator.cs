using FluentValidation;

namespace VideoGameStore.Application.Features.Game.Queries.GetGames
{
    public class GetGamesQueryValidator : AbstractValidator<GetGamesQuery>
    {
        public GetGamesQueryValidator()
        {
            RuleFor(x => x.Page)
            .Cascade(CascadeMode.Stop)
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} debe ser mayor o igual a 1");

            RuleFor(x => x.Size)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1)
                .WithMessage("{PropertyName} debe ser mayor o igual a 1")
                .LessThanOrEqualTo(100)
                .WithMessage("{PropertyName} no puede ser mayor a 100");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(100)
                .WithMessage("{PropertyName} Name no puede superar 100 caracteres")
                .When(x => x.Name is not null);
        }
    }
}