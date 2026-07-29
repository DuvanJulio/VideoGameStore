using FluentValidation;

namespace VideoGameStore.Application.Features.Order.Commands.InsertOrder
{
    public class InsertOrderCommandValidator : AbstractValidator<InsertOrderCommand>
    {
        public InsertOrderCommandValidator()
        {
            RuleFor(x => x.IdUser)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");

            RuleFor(x => x.Total)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} no puede ser negativo");
        }
    }
}
