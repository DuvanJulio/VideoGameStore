using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Models.Response;
using VideoGameStore.Infrastructure.Utils.Attributes;
using VideoGameStore.Application.Features.PlatformOwner.Commands.InsertPlatformOwner;
using VideoGameStore.Application.Features.PlatformOwner.Commands.UpdatePlatformOwner;
using VideoGameStore.Application.Features.PlatformOwner.Commands.DeletePlatformOwner;
using VideoGameStore.Application.Features.PlatformOwner.Queries.GetPlatformOwnerById;
using VideoGameStore.Application.Features.PlatformOwner.Queries.GetAllPlatformOwner;

namespace VideoGameStore.Presentation.Config.Controllers
{
    [Route("[action]")]
    [Produces("application/json")]
    [ApiController]
    [ControllerName("Platform Owner")]

    public class PlatformOwnerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlatformOwnerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Success<bool>>> InsertPlatformOwner(
            [FromBody] InsertPlatformOwnerCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpPut]
        public async Task<ActionResult<Success<bool>>> UpdatePlatformOwner(
            [FromBody] UpdatePlatformOwnerCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpDelete]
        public async Task<ActionResult<Success<bool>>> DeletePlatformOwner(
            [FromBody] DeletePlatformOwnerCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpGet]
        public async Task<ActionResult<Success<PlatformOwnerEntity>>> GetPlatformOwnerById(
            [FromQuery] GetPlatformOwnerByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(Success<PlatformOwnerEntity>.Create(data: result));
        }

        [HttpGet]
        public async Task<ActionResult<Success<List<PlatformOwnerEntity>>>> GetAllPlatformOwner(
            [FromQuery] GetAllPlatformOwnerQuery query, CancellationToken cancellationToken)
        {
            var queryResponse = await _mediator.Send(query, cancellationToken);

            return Ok(Success<List<PlatformOwnerEntity>>.Create(data: queryResponse));
        }


    }
}