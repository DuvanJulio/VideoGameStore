using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Models.Response;
using VideoGameStore.Infrastructure.Utils.Attributes;
using VideoGameStore.Application.Features.GamePlatform.Commands.InsertGamePlatform;
using VideoGameStore.Application.Features.GamePlatform.Commands.UpdateGamePlatform;
using VideoGameStore.Application.Features.GamePlatform.Commands.DeleteGamePlatform;
using VideoGameStore.Application.Features.GamePlatform.Queries.GetAllGamePlatform;
using VideoGameStore.Application.Features.GamePlatform.Queries.GetGamePlatformById;

namespace VideoGameStore.Presentation.Config.Controllers
{
    [Route("[action]")]
    [Produces("application/json")]
    [ApiController]
    [ControllerName("Game Platform")]
    public class GamePlatformController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GamePlatformController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Success<bool>>> InsertGamePlatform(
            [FromBody] InsertGamePlatformCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(Success<bool>.Create(data: result));
        }

        [HttpPut]
        public async Task<ActionResult<Success<bool>>> UpdateGamePlatform(
            [FromBody] UpdateGamePlatformCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(Success<bool>.Create(data: result));
        }

        [HttpDelete]
        public async Task<ActionResult<Success<bool>>> DeleteGamePlatform(
            [FromBody] DeleteGamePlatformCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(Success<bool>.Create(data: result));
        }

        [HttpGet]
        public async Task<ActionResult<Success<List<GamePlatformEntity>>>> GetAllGamePlatform(
            [FromQuery] GetAllGamePlatformQuery query, CancellationToken cancellationToken)
        {
            var queryResponse = await _mediator.Send(query, cancellationToken);
            return Ok(Success<List<GamePlatformEntity>>.Create(data: queryResponse));
        }

        [HttpGet]
        public async Task<ActionResult<Success<GamePlatformEntity>>> GetGamePlatformById(
            [FromQuery] GetGamePlatformByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(Success<GamePlatformEntity>.Create(data: result));
        }
    }
}
