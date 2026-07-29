using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Models.Response;
using VideoGameStore.Infrastructure.Utils.Attributes;
using VideoGameStore.Application.Features.ProductVariant.Commands.InsertProductVariant;
using VideoGameStore.Application.Features.ProductVariant.Commands.UpdateProductVariant;
using VideoGameStore.Application.Features.ProductVariant.Commands.DeleteProductVariant;
using VideoGameStore.Application.Features.ProductVariant.Queries.GetAllProductVariant;
using VideoGameStore.Application.Features.ProductVariant.Queries.GetProductVariantById;

namespace VideoGameStore.Presentation.Config.Controllers
{
    [Route("[action]")]
    [Produces("application/json")]
    [ApiController]
    [ControllerName("Product Variant")]
    public class ProductVariantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductVariantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Success<bool>>> InsertProductVariant(
            [FromBody] InsertProductVariantCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(Success<bool>.Create(data: result));
        }

        [HttpPut]
        public async Task<ActionResult<Success<bool>>> UpdateProductVariant(
            [FromBody] UpdateProductVariantCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(Success<bool>.Create(data: result));
        }

        [HttpDelete]
        public async Task<ActionResult<Success<bool>>> DeleteProductVariant(
            [FromBody] DeleteProductVariantCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(Success<bool>.Create(data: result));
        }

        [HttpGet]
        public async Task<ActionResult<Success<List<ProductVariantEntity>>>> GetAllProductVariant(
            [FromQuery] GetAllProductVariantQuery query, CancellationToken cancellationToken)
        {
            var queryResponse = await _mediator.Send(query, cancellationToken);
            return Ok(Success<List<ProductVariantEntity>>.Create(data: queryResponse));
        }

        [HttpGet]
        public async Task<ActionResult<Success<ProductVariantEntity>>> GetProductVariantById(
            [FromQuery] GetProductVariantByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(Success<ProductVariantEntity>.Create(data: result));
        }
    }
}
