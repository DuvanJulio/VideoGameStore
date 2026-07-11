using FluentValidation;

namespace VideoGameStore.Application.Features.DeliveryType.Queries.GetDeliveryTypesById
{
    public class GetDeliveryTypeByIdQueryValidator : AbstractValidator<GetDeliveryTypesByIdQuery>
    {
        public GetDeliveryTypeByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}
