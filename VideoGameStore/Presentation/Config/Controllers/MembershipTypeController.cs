using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Models.Response;
using VideoGameStore.Infrastructure.Utils.Attributes;
using VideoGameStore.Application.Features.MembershipType.Commands.InsertMembershipType;
using VideoGameStore.Application.Features.MembershipType.Commands.UpdateMembershipType;
using VideoGameStore.Application.Features.MembershipType.Commands.DeleteMembershipType;
using VideoGameStore.Application.Features.MembershipType.Queries.GetAllMembershipType;
using VideoGameStore.Application.Features.MembershipType.Queries.GetMembershipTypeById;

namespace VideoGameStore.Presentation.Config.Controllers
{
    [Route("[action]")]
    [Produces("application/json")]
    [ApiController]
    [ControllerName("Membership Type")]
    public class MembershipTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembershipTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Success<bool>>> InsertMembershipType(
            [FromBody] InsertMembershipTypeCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpPut]
        public async Task<ActionResult<Success<bool>>> UpdateMembershipType(
            [FromBody] UpdateMembershipTypeCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpDelete]
        public async Task<ActionResult<Success<bool>>> DeleteMembershipType(
            [FromBody] DeleteMembershipTypeCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpGet]
        public async Task<ActionResult<Success<List<MembershipTypeEntity>>>> GetAllMembershipType(
            [FromQuery] GetAllMembershipTypeQuery query, CancellationToken cancellationToken)
        {
            var queryResponse = await _mediator.Send(query, cancellationToken);

            return Ok(Success<List<MembershipTypeEntity>>.Create(data: queryResponse));
        }

        [HttpGet]
        public async Task<ActionResult<Success<MembershipTypeEntity>>> GetMembershipTypeById(
            [FromQuery] GetMembershipTypeByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(Success<MembershipTypeEntity>.Create(data: result));
        }
    }
}
