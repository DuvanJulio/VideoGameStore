using FluentValidation;

namespace VideoGameStore.Application.Features.AccountType.Queries.GetAccountTypesById
{
    public class GetAccountTypeByIdQueryValidator : AbstractValidator<GetAccountTypesByIdQuery>
    {
        public GetAccountTypeByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}
