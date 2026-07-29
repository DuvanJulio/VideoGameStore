using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.OrderDetail.Commands.DeleteOrderDetail
{
    public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;

        public DeleteOrderDetailCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var orderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(request.Id, cancellationToken);

            if (orderDetail is null)
                throw new NotFoundException("");

            orderDetail.IsActive = false;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}
