using FluentValidation;
using VideoGameStore.Application.Features.DeliveryType.Commands.DeleteDeliveryType;

namespace VideoGameStore.Application.Features.DeliveryType.Commands
{
    public class DeleteDeliveryTypeCommandValidator : AbstractValidator<DeleteDeliveryTypeCommand>
    {
        public DeleteDeliveryTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}