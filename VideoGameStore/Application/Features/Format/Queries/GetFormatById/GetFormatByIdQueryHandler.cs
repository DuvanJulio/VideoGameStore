using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.Format.Queries.GetFormatById
{
    public class GetFormatByIdQueryHandler : IRequestHandler<GetFormatByIdQuery, FormatEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFormatByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FormatEntity> Handle(GetFormatByIdQuery request, CancellationToken cancellationToken)
        {
            var format = await _unitOfWork.FormatRepository.GetByIdAsync(request.Id);

            if (format is null)
                throw new NotFoundException(nameof(FormatEntity), request.Id);

            return format;
        }
    }
}