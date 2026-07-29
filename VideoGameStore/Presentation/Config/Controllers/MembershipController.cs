using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Models.Response;
using VideoGameStore.Infrastructure.Utils.Attributes;
using VideoGameStore.Application.Features.Membership.Commands.InsertMembership;
using VideoGameStore.Application.Features.Membership.Commands.UpdateMembership;
using VideoGameStore.Application.Features.Membership.Commands.DeleteMembership;
using VideoGameStore.Application.Features.Membership.Queries.GetAllMembership;
using VideoGameStore.Application.Features.Membership.Queries.GetMembershipById;

namespace VideoGameStore.Presentation.Config.Controllers
{
    [Route("[action]")]
    [Produces("application/json")]
    [ApiController]
    [ControllerName("Membership")]
    public class MembershipController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembershipController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Success<bool>>> InsertMembership(
            [FromBody] InsertMembershipCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(Success<bool>.Create(data: result));
        }

        [HttpPut]
        public async Task<ActionResult<Success<bool>>> UpdateMembership(
            [FromBody] UpdateMembershipCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(Success<bool>.Create(data: result));
        }

        [HttpDelete]
        public async Task<ActionResult<Success<bool>>> DeleteMembership(
            [FromBody] DeleteMembershipCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(Success<bool>.Create(data: result));
        }

        [HttpGet]
        public async Task<ActionResult<Success<List<MembershipEntity>>>> GetAllMembership(
            [FromQuery] GetAllMembershipQuery query, CancellationToken cancellationToken)
        {
            var queryResponse = await _mediator.Send(query, cancellationToken);
            return Ok(Success<List<MembershipEntity>>.Create(data: queryResponse));
        }

        [HttpGet]
        public async Task<ActionResult<Success<MembershipEntity>>> GetMembershipById(
            [FromQuery] GetMembershipByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(Success<MembershipEntity>.Create(data: result));
        }
    }
}
