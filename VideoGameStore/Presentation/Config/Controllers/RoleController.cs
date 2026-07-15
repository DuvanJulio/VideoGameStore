using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameStore.Application.Features.Auth.Commands.Role;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Presentation.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RoleController : ControllerBase
    {
        private readonly ISender _sender;

        public RoleController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("insert")]
        public async Task<IActionResult> InsertRole([FromBody] InsertRoleCommand command, CancellationToken cancellationToken)
        {
            var id = await _sender.Send(command, cancellationToken);
            return Ok(new { Id = id, Message = "Rol insertado exitosamente." });
        }
    }
}