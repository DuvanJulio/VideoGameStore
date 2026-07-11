using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Models.Response;
using VideoGameStore.Infrastructure.Utils.Attributes;
using VideoGameStore.Application.Features.ProductType.Commands.InsertProductType;
using VideoGameStore.Application.Features.ProductType.Commands.UpdateProductType;
using VideoGameStore.Application.Features.ProductType.Commands.DeleteProductType;
using VideoGameStore.Application.Features.ProductType.Queries.GetProducTypeById;
using VideoGameStore.Application.Features.ProductType.Queries.GetAllProductType;


namespace VideoGameStore.Presentation.Config.Controllers
{
    [Route("[action]")]
    [Produces("application/json")]
    [ApiController]
    [ControllerName("Product Type")]

    public class ProductTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Success<bool>>> InsertProductType(
            [FromBody] InsertProductTypeCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpPut]
        public async Task<ActionResult<Success<bool>>> UpdateProductType(
            [FromBody] UpdateProductTypeCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpDelete]
        public async Task<ActionResult<Success<bool>>> DeleteProductType(
            [FromBody] DeleteProductTypeCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpGet]
        public async Task<ActionResult<Success<ProductTypeEntity>>> GetProducTypeById(
            [FromQuery] GetProducTypeByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(Success<ProductTypeEntity>.Create(data: result));
        }

        [HttpGet]
        public async Task<ActionResult<Success<List<ProductTypeEntity>>>> GetAllProductType(
            [FromQuery] GetAllProductTypeQuery query, CancellationToken cancellationToken)
        {
            var queryResponse = await _mediator.Send(query, cancellationToken);

            return Ok(Success<List<ProductTypeEntity>>.Create(data: queryResponse));
        }
        
    }
    
}