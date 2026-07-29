using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Models.Response;
using VideoGameStore.Infrastructure.Utils.Attributes;
using VideoGameStore.Application.Features.OrderDetail.Commands.InsertOrderDetail;
using VideoGameStore.Application.Features.OrderDetail.Commands.UpdateOrderDetail;
using VideoGameStore.Application.Features.OrderDetail.Commands.DeleteOrderDetail;
using VideoGameStore.Application.Features.OrderDetail.Queries.GetAllOrderDetail;
using VideoGameStore.Application.Features.OrderDetail.Queries.GetOrderDetailById;

namespace VideoGameStore.Presentation.Config.Controllers
{
    [Route("[action]")]
    [Produces("application/json")]
    [ApiController]
    [ControllerName("Order Detail")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Success<bool>>> InsertOrderDetail(
            [FromBody] InsertOrderDetailCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(Success<bool>.Create(data: result));
        }

        [HttpPut]
        public async Task<ActionResult<Success<bool>>> UpdateOrderDetail(
            [FromBody] UpdateOrderDetailCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(Success<bool>.Create(data: result));
        }

        [HttpDelete]
        public async Task<ActionResult<Success<bool>>> DeleteOrderDetail(
            [FromBody] DeleteOrderDetailCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(Success<bool>.Create(data: result));
        }

        [HttpGet]
        public async Task<ActionResult<Success<List<OrderDetailEntity>>>> GetAllOrderDetail(
            [FromQuery] GetAllOrderDetailQuery query, CancellationToken cancellationToken)
        {
            var queryResponse = await _mediator.Send(query, cancellationToken);
            return Ok(Success<List<OrderDetailEntity>>.Create(data: queryResponse));
        }

        [HttpGet]
        public async Task<ActionResult<Success<OrderDetailEntity>>> GetOrderDetailById(
            [FromQuery] GetOrderDetailByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(Success<OrderDetailEntity>.Create(data: result));
        }
    }
}
