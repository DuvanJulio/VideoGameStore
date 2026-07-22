using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.ProductType.Commands.InsertProductType
{
    public class InsertProductTypeCommandHandler : IRequestHandler<InsertProductTypeCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        private readonly ICurrentUser _currentUser;

    public InsertProductTypeCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;

            _currentUser = currentUser;
        }

        public async Task<bool> Handle(InsertProductTypeCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var productType = new ProductTypeEntity
            {
                Name = request.Name
            };

            await _unitOfWork.ProductTypeRepository.AddAsync(productType);
            await _unitOfWork.SaveChangeAsync();

            return true;
        }
    }
}