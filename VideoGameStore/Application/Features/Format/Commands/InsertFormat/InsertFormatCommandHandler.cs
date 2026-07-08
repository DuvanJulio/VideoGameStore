using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Format.Commands.InsertFormat
{
    public class InsertFormatCommandHandler : IRequestHandler<InsertFormatCommand, bool>
    {
        public readonly IUnitOfWork _unitOfWork;

        public InsertFormatCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(InsertFormatCommand request, CancellationToken cancellationToken)
        {
            var format = new FormatEntity
            {
                Name = request.Name
            };

            await _unitOfWork.FormatRepository.AddAsync(format);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}