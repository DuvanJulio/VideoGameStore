using FluentValidation;

namespace VideoGameStore.Application.Features.ProductVariant.Queries.GetProductVariantById
{
    public class GetProductVariantByIdQueryValidator : AbstractValidator<GetProductVariantByIdQuery>
    {
        public GetProductVariantByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}
