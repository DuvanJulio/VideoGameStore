using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.ProductType.Commands.InsertProductType
{
    public class InsertProductTypeCommandHandler : IRequestHandler<InsertProductTypeCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

    public InsertProductTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

        public async Task<bool> Handle(InsertProductTypeCommand request, CancellationToken cancellationToken)
        {
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