using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Enums;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.Order.Commands.InsertOrder
{
    public class InsertOrderCommandHandler : IRequestHandler<InsertOrderCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;

        public InsertOrderCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(InsertOrderCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var order = new OrderEntity
            {
                IdUser = request.IdUser,
                Total = request.Total
            };

            await _unitOfWork.OrderRepository.AddAsync(order);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}
