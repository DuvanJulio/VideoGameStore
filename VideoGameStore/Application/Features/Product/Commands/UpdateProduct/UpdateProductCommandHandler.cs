using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id, cancellationToken);
            if (product is null)
                throw new NotFoundException();

            product.Name = request.Name;
            product.Description = request.Description;
            product.IdGamePlatform = request.IdGamePlatform;
            product.IdProductType = request.IdProductType;
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return true;
        }
    }
}
