using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Format.Commands.DeleteFormat
{
    public class DeleteAccountTypeCommandHandler : IRequestHandler<DeleteFormatCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAccountTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteFormatCommand request, CancellationToken cancellationToken)
        {
            var format = await _unitOfWork.FormatRepository.GetByIdAsync(request.Id, cancellationToken);

            if (format is null)
                throw new NotFoundException(nameof(FormatEntity));

            format.IsActive = false;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}