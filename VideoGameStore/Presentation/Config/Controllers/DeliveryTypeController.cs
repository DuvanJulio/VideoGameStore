using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameStore.Application.Features.DeliveryType.Commands.InsertDeliveryType;
using VideoGameStore.Application.Features.DeliveryType.Commands.UpdateDeliveryType;
using VideoGameStore.Application.Features.DeliveryType.Commands.DeleteDeliveryType;
using VideoGameStore.Application.Features.DeliveryType.Queries.GetDeliveryTypes;
using VideoGameStore.Application.Features.DeliveryType.Queries.GetDeliveryTypesById;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Models.Response;
using VideoGameStore.Infrastructure.Utils.Attributes;

namespace VideoGameStore.Presentation.Config.Controllers
{
    [Route("[action]")]
    [Produces("application/json")]
    [ApiController]
    [ControllerName("Delivery Type")]
    public class DeliveryTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeliveryTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Success<bool>>> InsertDeliveryType(
            [FromBody] InsertDeliveryTypeCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpPut]
        public async Task<ActionResult<Success<bool>>> UpdateDeliveryType(
            [FromBody] UpdateDeliveryTypeCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpDelete]
        public async Task<ActionResult<Success<bool>>> DeleteDeliveryType(
            [FromBody] DeleteDeliveryTypeCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpGet]
        public async Task<ActionResult<Success<List<DeliveryTypeEntity>>>> GetDeliveryTypes(
            [FromQuery] GetDeliveryTypeQuery query, CancellationToken cancellationToken)
        {
            var queryResponse = await _mediator.Send(query, cancellationToken);

            var response = Success<List<DeliveryTypeEntity>>.Create(data: queryResponse);

            return response;
        }

        [HttpGet]
        public async Task<ActionResult<Success<DeliveryTypeEntity>>> GetDeliveryTypesById(
            [FromQuery] GetDeliveryTypesByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(Success<DeliveryTypeEntity>.Create(data: result));
        }
    }
}