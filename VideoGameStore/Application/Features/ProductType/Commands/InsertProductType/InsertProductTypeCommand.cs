using MediatR;

namespace VideoGameStore.Application.Features.ProductType.Commands.InsertProductType
{
    public class InsertProductTypeCommand : IRequest<bool>
    {
        public string Name { get; set; } = string.Empty;
    }
}