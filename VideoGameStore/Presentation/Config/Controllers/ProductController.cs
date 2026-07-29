using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Models.Response;
using VideoGameStore.Infrastructure.Utils.Attributes;
using VideoGameStore.Application.Features.Product.Commands.InsertProduct;
using VideoGameStore.Application.Features.Product.Commands.UpdateProduct;
using VideoGameStore.Application.Features.Product.Commands.DeleteProduct;
using VideoGameStore.Application.Features.Product.Queries.GetAllProduct;
using VideoGameStore.Application.Features.Product.Queries.GetProductById;

namespace VideoGameStore.Presentation.Config.Controllers
{
    [Route("[action]")]
    [Produces("application/json")]
    [ApiController]
    [ControllerName("Product")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Success<bool>>> InsertProduct(
            [FromBody] InsertProductCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(Success<bool>.Create(data: result));
        }

        [HttpPut]
        public async Task<ActionResult<Success<bool>>> UpdateProduct(
            [FromBody] UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(Success<bool>.Create(data: result));
        }

        [HttpDelete]
        public async Task<ActionResult<Success<bool>>> DeleteProduct(
            [FromBody] DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(Success<bool>.Create(data: result));
        }

        [HttpGet]
        public async Task<ActionResult<Success<List<ProductEntity>>>> GetAllProduct(
            [FromQuery] GetAllProductQuery query, CancellationToken cancellationToken)
        {
            var queryResponse = await _mediator.Send(query, cancellationToken);
            return Ok(Success<List<ProductEntity>>.Create(data: queryResponse));
        }

        [HttpGet]
        public async Task<ActionResult<Success<ProductEntity>>> GetProductById(
            [FromQuery] GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(Success<ProductEntity>.Create(data: result));
        }
    }
}
