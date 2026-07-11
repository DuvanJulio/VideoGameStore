using FluentValidation;

namespace VideoGameStore.Application.Features.ProductType.Commands.DeleteProductType
{
    public class DeleteProductTypeValidator : AbstractValidator<DeleteProductTypeCommand>
    {
        public DeleteProductTypeValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}