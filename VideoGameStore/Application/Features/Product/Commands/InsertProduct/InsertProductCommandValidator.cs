using FluentValidation;

namespace VideoGameStore.Application.Features.Product.Commands.InsertProduct
{
    public class InsertProductCommandValidator : AbstractValidator<InsertProductCommand>
    {
        public InsertProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                .NotEmpty().WithMessage("{PropertyName} no puede estar en blanco")
                .MaximumLength(200).WithMessage("{PropertyName} excedio el limite maximo de 200 caracteres");

            RuleFor(x => x.Description)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                .NotEmpty().WithMessage("{PropertyName} no puede estar en blanco")
                .MaximumLength(500).WithMessage("{PropertyName} excedio el limite maximo de 500 caracteres");

            RuleFor(x => x.IdGamePlatform)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");

            RuleFor(x => x.IdProductType)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}
