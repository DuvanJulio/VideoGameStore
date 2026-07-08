using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameStore.Application.Features.AccountType.Commands.InsertAccountType;
using VideoGameStore.Application.Features.AccountType.Commands.UpdateAccountType;
using VideoGameStore.Application.Features.AccountType.Commands.DeleteAccountType;
using VideoGameStore.Application.Features.AccountType.Queries.GetAccountTypes;
using VideoGameStore.Application.Features.AccountType.Queries.GetAccountTypesById;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Models.Response;
using VideoGameStore.Infrastructure.Utils.Attributes;

namespace VideoGameStore.Presentation.Config.Controllers
{
    [Route("[action]")]
    [Produces("application/json")]
    [ApiController]
    [ControllerName("Account Type")]
    public class AccountTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Success<bool>>> InsertAccountType(
            [FromBody] InsertAccountTypeCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpPut]
        public async Task<ActionResult<Success<bool>>> UpdateAccountType(
            [FromBody] UpdateAccountTypeCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpDelete]
        public async Task<ActionResult<Success<bool>>> DeleteAccountType(
            [FromBody] DeleteAccountTypeCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(Success<bool>.Create(data: result));
        }

        [HttpGet]
        public async Task<ActionResult<Success<List<AccountTypeEntity>>>> GetAccountTypes(
            [FromQuery] GetAccountTypeQuery query, CancellationToken cancellationToken)
        {
            var queryResponse = await _mediator.Send(query, cancellationToken);

            var response = Success<List<AccountTypeEntity>>.Create(data: queryResponse);

            return response;
        }

        [HttpGet]
        public async Task<ActionResult<Success<AccountTypeEntity>>> GetAccountTypesById(
            [FromQuery] GetAccountTypesByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(Success<AccountTypeEntity>.Create(data: result));
        }
    }
}
