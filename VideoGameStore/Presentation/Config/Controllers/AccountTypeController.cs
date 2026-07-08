using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameStore.Application.Features.AccountType.Commands.InsertAccountType;
using VideoGameStore.Application.Features.AccountType.Commands.InsertAccountType;
using VideoGameStore.Application.Features.AccountType.Queries.GetAccountTypes;
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

        [HttpGet]
        public async Task<ActionResult<Success<List<AccountTypeEntity>>>> GetAccountTypes([FromQuery] GetAccountTypeQuery query, CancellationToken cancellationToken)
        {
            var queryResponse = await _mediator.Send(query, cancellationToken);

            var response = Success<List<AccountTypeEntity>>.Create(
                data: queryResponse
            );

            return response;
        }
    }
}
