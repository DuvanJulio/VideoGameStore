using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Models.Response;
using VideoGameStore.Infrastructure.Utils.Attributes;

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

        
    }
}