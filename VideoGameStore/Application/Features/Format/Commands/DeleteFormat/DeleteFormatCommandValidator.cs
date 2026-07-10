using FluentValidation;

namespace VideoGameStore.Application.Features.Format.Commands.DeleteFormat
{
    public class DeleteFormatCommandValidator : AbstractValidator<DeleteFormatCommand>
    {
        public DeleteFormatCommandValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}