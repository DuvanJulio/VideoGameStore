using MediatR;

namespace VideoGameStore.Application.Features.ProductType.Commands.DeleteProductType
{
    public class DeleteProductTypeCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}