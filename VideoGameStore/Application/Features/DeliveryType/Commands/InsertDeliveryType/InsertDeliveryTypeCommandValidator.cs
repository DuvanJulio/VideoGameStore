using FluentValidation;


namespace VideoGameStore.Application.Features.DeliveryType.Commands.InsertDeliveryType
{
    public class InsertDeliveryTypeCommandValidator : AbstractValidator<InsertDeliveryTypeCommand>
    {
        public InsertDeliveryTypeCommandValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                .NotEmpty().WithMessage("{PropertyName} no puede estar en blanco")
                .MaximumLength(100).WithMessage("{PropertyName} excedio el limite maximo de 200 caracteres");
        }
    }
}