using FluentValidation;

namespace VideoGameStore.Application.Features.ProductType.Queries.GetProducTypeById
{
    public class GetProducTypeByIdValidator : AbstractValidator<GetProducTypeByIdQuery>
    {
        public GetProducTypeByIdValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}