using FluentValidation;
using MediatR;

namespace VideoGameStore.Application.Features.Platform.Commands.DeletePlatform
{
    public class DeletePlatformCommandValidator : AbstractValidator<DeletePlatformCommand>
    {
        public DeletePlatformCommandValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0");
        }
    }
}