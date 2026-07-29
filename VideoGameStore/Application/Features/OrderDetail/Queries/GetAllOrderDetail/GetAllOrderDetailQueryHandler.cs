using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.OrderDetail.Queries.GetAllOrderDetail
{
    public class GetAllOrderDetailQueryHandler : IRequestHandler<GetAllOrderDetailQuery, List<OrderDetailEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllOrderDetailQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<OrderDetailEntity>> Handle(GetAllOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var orderDetails = await _unitOfWork.OrderDetailRepository.GetAllAsync();

            return orderDetails.ToList();
        }
    }
}
