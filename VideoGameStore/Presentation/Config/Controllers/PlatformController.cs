using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Models.Response;
using VideoGameStore.Infrastructure.Utils.Attributes;
using VideoGameStore.Application.Features.Platform.Commands.InsertPlatform;
using VideoGameStore.Application.Features.Platform.Commands.UpdatePlatform;
using VideoGameStore.Application.Features.Platform.Commands.DeletePlatform;
using VideoGameStore.Application.Features.Platform.Queries.GetAllPlatform;
using VideoGameStore.Application.Features.Platform.Queries.GetPlatformById;

namespace VideoGameStore.Presentation.Config.Controllers
{
    [Route("[action]")]
    [Produces("application/json")]
    [ApiController]
    [ControllerName("Platform")]
    public class PlatformController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlatformController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Success<bool>>> InsertPlatform(
            [FromBody] InsertPlatformCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpPut]
        public async Task<ActionResult<Success<bool>>> UpdatePlatform(
            [FromBody] UpdatePlatformCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpDelete]
        public async Task<ActionResult<Success<bool>>> DeletePlatform(
            [FromBody] DeletePlatformCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpGet]
        public async Task<ActionResult<Success<List<PlatformEntity>>>> GetAllPlatform(
            [FromQuery] GetAllPlatformQuery query, CancellationToken cancellationToken)
        {
            var queryResponse = await _mediator.Send(query, cancellationToken);

            return Ok(Success<List<PlatformEntity>>.Create(data: queryResponse));
        }

        [HttpGet]
        public async Task<ActionResult<Success<PlatformEntity>>> GetPlatformById(
            [FromQuery] GetPlatformByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(Success<PlatformEntity>.Create(data: result));
        }
    }
}
