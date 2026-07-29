using FluentValidation;

namespace VideoGameStore.Application.Features.ProductVariant.Commands.InsertProductVariant
{
    public class InsertProductVariantCommandValidator : AbstractValidator<InsertProductVariantCommand>
    {
        public InsertProductVariantCommandValidator()
        {
            RuleFor(x => x.Price)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");

            RuleFor(x => x.Stock)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} no puede ser negativo");

            RuleFor(x => x.IdProduct)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");

            RuleFor(x => x.IdDeliveryType)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}
