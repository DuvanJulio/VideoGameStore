using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Format.Queries.GetAllFormat
{
    public class GetAccountTypeQueryHandler : IRequestHandler<GetAllFormatQuery, List<FormatEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAccountTypeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<FormatEntity>> Handle(GetAllFormatQuery request, CancellationToken cancellationToken)
        {
            var format = await _unitOfWork.FormatRepository.GetAllAsync();

            return format.ToList();
        }
    }
}