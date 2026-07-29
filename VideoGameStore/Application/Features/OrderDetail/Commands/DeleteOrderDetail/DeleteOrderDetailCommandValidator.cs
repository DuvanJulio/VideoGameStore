using FluentValidation;

namespace VideoGameStore.Application.Features.OrderDetail.Commands.DeleteOrderDetail
{
    public class DeleteOrderDetailCommandValidator : AbstractValidator<DeleteOrderDetailCommand>
    {
        public DeleteOrderDetailCommandValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}
