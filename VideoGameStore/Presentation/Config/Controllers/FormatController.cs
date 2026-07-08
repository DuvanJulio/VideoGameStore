using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Models.Response;
using VideoGameStore.Infrastructure.Utils.Attributes;
using VideoGameStore.Application.Features.Format.Commands.InsertFormat;
using VideoGameStore.Application.Features.Format.Commands.UpdateFormat;
using VideoGameStore.Application.Features.Format.Commands.DeleteFormat;
using VideoGameStore.Application.Features.Format.Queries.GetFormatById;
using VideoGameStore.Application.Features.Format.Queries.GetAllFormat;

namespace VideoGameStore.Presentation.Config.Controllers
{
    [Route("[action]")]
    [Produces("application/json")]
    [ApiController]
    [ControllerName("Format")]

    public class FormatController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FormatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Success<bool>>> InsertFormat(
            [FromBody] InsertFormatCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpPut]
        public async Task<ActionResult<Success<bool>>> UpdateFormat(
            [FromBody] UpdateFormatCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpDelete]
        public async Task<ActionResult<Success<bool>>> DeleteFormat(
            [FromBody] DeleteFormatCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpGet]
        public async Task<ActionResult<Success<FormatEntity>>> GetFormatById(
            [FromQuery] GetFormatByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(Success<FormatEntity>.Create(data: result));
        }

        [HttpGet]
        public async Task<ActionResult<Success<List<FormatEntity>>>> GetAllFormat(
            [FromQuery] GetAllFormatQuery query, CancellationToken cancellationToken)
        {
            var queryResponse = await _mediator.Send(query, cancellationToken);

            return Ok(Success<List<FormatEntity>>.Create(data: queryResponse));
        }

    }
}