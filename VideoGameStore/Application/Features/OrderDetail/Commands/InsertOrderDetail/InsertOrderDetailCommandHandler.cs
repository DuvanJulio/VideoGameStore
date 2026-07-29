using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.OrderDetail.Commands.InsertOrderDetail
{
    public class InsertOrderDetailCommandHandler : IRequestHandler<InsertOrderDetailCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;

        public InsertOrderDetailCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(InsertOrderDetailCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var orderDetail = new OrderDetailEntity
            {
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice,
                IdProductVariant = request.IdProductVariant,
                IdOrder = request.IdOrder,
                IdMembership = request.IdMembership
            };

            await _unitOfWork.OrderDetailRepository.AddAsync(orderDetail);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}
