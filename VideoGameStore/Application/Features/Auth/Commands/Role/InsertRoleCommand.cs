using MediatR;

namespace VideoGameStore.Application.Features.Auth.Commands.Role
{
    public class InsertRoleCommand : IRequest<bool>
    {
        public string Name { get; set; } = string.Empty;
    }
}