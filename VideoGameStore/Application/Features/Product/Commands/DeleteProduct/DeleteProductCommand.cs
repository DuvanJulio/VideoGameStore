using MediatR;

namespace VideoGameStore.Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
