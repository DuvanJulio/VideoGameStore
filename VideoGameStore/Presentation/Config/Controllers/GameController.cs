using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using VideoGameStore.Application.Context;
using VideoGameStore.Application.Features.Game.Commands.DeleteGame;
using VideoGameStore.Application.Features.Game.Commands.InsertGame;
using VideoGameStore.Application.Features.Game.Commands.SoftDeleteGame;
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
        private readonly ICurrentUser _currentUser;

        public GameController(IMediator mediator, ICurrentUser currentUser)
        {
            _mediator = mediator;
            _currentUser = currentUser;
        }

        [HttpPost]
        public async Task<ActionResult<Success<bool>>> InsertGame(
            [FromBody] InsertGameCommand command,
            CancellationToken cancellationToken)
        {
            if (!_currentUser.IsAuthenticated)
                return StatusCode(401, new Failure<bool>
                {
                    Error = "Usuario no autenticado",
                    Message = "Acceso denegado"
                });

            var user = await _currentUser.GetUserAsync();

            if (_currentUser.Role != "Admin")
                return StatusCode(403, new Failure<bool>
                {
                    Error = "Solo el Rol Admin puede insertar juegos",
                    Message = "Acceso denegado"
                });

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

        [HttpDelete]

        public async Task<ActionResult<Success<bool>>> SoftDeleteGame(
            [FromBody] SoftDeleteGameCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }
        
        
        
    }
}
