using MediatR;

namespace VideoGameStore.Application.Features.Product.Commands.InsertProduct
{
    public class InsertProductCommand : IRequest<bool>
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public long IdGamePlatform { get; set; }

        public long IdProductType { get; set; }
    }
}