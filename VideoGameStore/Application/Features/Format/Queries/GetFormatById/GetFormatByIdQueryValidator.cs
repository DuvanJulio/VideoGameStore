
using FluentValidation;

namespace VideoGameStore.Application.Features.Format.Queries.GetFormatById
{
    public class GetFormatByIdQueryValidator : AbstractValidator<GetFormatByIdQuery>
    {
        public GetFormatByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}
