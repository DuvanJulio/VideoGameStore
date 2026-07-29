using FluentValidation;

namespace VideoGameStore.Application.Features.OrderDetail.Queries.GetOrderDetailById
{
    public class GetOrderDetailByIdQueryValidator : AbstractValidator<GetOrderDetailByIdQuery>
    {
        public GetOrderDetailByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}
