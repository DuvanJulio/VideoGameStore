using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.OrderDetail.Commands.UpdateOrderDetail
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;

        public UpdateOrderDetailCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var orderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(request.Id, cancellationToken);
            if (orderDetail is null)
                throw new NotFoundException();

            orderDetail.Quantity = request.Quantity;
            orderDetail.UnitPrice = request.UnitPrice;
            orderDetail.IdProductVariant = request.IdProductVariant;
            orderDetail.IdOrder = request.IdOrder;
            orderDetail.IdMembership = request.IdMembership;
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return true;
        }
    }
}
