using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.ProductType.Commands.UpdateProductType
{
    public class UpdateProductTypeCommandHandler : IRequestHandler<UpdateProductTypeCommand, bool>
    {
        public readonly IUnitOfWork _unitOfWork;

        private readonly ICurrentUser _currentUser;

        public UpdateProductTypeCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;

            _currentUser = currentUser;
        }

         public async Task<bool> Handle(UpdateProductTypeCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var productType = await _unitOfWork.ProductTypeRepository.GetByIdAsync(request.Id);

            if (productType is null)
                throw new NotFoundException(nameof(ProductTypeEntity), request.Id);

            productType.Name = request.Name;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}