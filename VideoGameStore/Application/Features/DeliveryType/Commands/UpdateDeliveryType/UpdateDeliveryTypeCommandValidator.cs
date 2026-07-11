using FluentValidation;

namespace VideoGameStore.Application.Features.DeliveryType.Commands.UpdateDeliveryType
{
    public class UpdateDeliveryTypeCommandValidator : AbstractValidator<UpdateDeliveryTypeCommand>
    {
        public UpdateDeliveryTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                .NotEmpty().WithMessage("{PropertyName} no puede estar en blanco")
                .MaximumLength(100).WithMessage("{PropertyName} excedio el limite maximo de 200 caracteres");
        }
    }
}