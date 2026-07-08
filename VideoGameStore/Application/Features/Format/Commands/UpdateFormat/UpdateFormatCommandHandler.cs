using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Format.Commands.UpdateFormat
{
    public class UpdateFormatCommandHanlder : IRequestHandler<UpdateFormatCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFormatCommandHanlder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateFormatCommand request, CancellationToken cancellationToken)
        {
            var format = await _unitOfWork.FormatRepository.GetByIdAsync(request.Id);

            if (format is null)
                throw new NotFoundException(nameof(FormatEntity), request.Id);

            format.Name = request.Name;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}