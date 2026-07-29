using MediatR;

namespace VideoGameStore.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long IdGamePlatform { get; set; }
        public long IdProductType { get; set; }
    }
}
