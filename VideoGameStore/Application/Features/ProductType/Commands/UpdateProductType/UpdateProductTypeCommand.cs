using MediatR;

namespace VideoGameStore.Application.Features.ProductType.Commands.UpdateProductType
{
    public class UpdateProductTypeCommand : IRequest<bool>
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}