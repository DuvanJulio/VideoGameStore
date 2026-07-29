using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.OrderDetail.Queries.GetOrderDetailById
{
    public class GetOrderDetailByIdQueryHandler : IRequestHandler<GetOrderDetailByIdQuery, OrderDetailEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOrderDetailByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderDetailEntity> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var orderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(request.Id);

            if (orderDetail is null)
                throw new NotFoundException();

            return orderDetail;
        }
    }
}
