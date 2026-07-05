using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameStore.Application.Features.Game.Commands.DeleteGame;
using VideoGameStore.Application.Features.Game.Commands.InsertGame;
using VideoGameStore.Application.Features.Game.Commands.UpdateGame;
using VideoGameStore.Application.Features.Game.Queries.GetGameById;
using VideoGameStore.Application.Features.Game.Queries.GetGames;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Models.Response;
using VideoGameStore.Infrastructure.Utils.Attributes;

namespace VideoGameStore.Presentation.Config.Controllers
{
    [Route("[action]")]
    [Produces("application/json")]
    [ApiController]
    [ControllerName("Game")]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Success<bool>>> InsertGame(
            [FromBody] InsertGameCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpPut]
        public async Task<ActionResult<Success<bool>>> UpdateGame(
            [FromBody] UpdateGameCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpGet]
        public async Task<ActionResult<Success<PagedResponse<GameEntity>>>> GetGames(
            [FromQuery] GetGamesQuery query,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(Success<PagedResponse<GameEntity>>.Create(data: result));
        }

        [HttpGet]
        public async Task<ActionResult<Success<GameEntity>>> GetGameById(
            [FromQuery] GetGameByIdQuery query,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(Success<GameEntity>.Create(data: result));
        }

        [HttpDelete]

        public async Task<ActionResult<Success<bool>>> DeleteGame(
            [FromBody] DeleteGameCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }
    }
}
