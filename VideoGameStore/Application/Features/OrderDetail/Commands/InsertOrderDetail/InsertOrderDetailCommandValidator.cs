using FluentValidation;

namespace VideoGameStore.Application.Features.OrderDetail.Commands.InsertOrderDetail
{
    public class InsertOrderDetailCommandValidator : AbstractValidator<InsertOrderDetailCommand>
    {
        public InsertOrderDetailCommandValidator()
        {
            RuleFor(x => x.Quantity)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");

            RuleFor(x => x.UnitPrice)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");

            RuleFor(x => x.IdProductVariant)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");

            RuleFor(x => x.IdOrder)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");

            RuleFor(x => x.IdMembership)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}
