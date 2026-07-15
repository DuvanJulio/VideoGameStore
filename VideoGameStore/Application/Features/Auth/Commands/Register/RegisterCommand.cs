using MediatR;

namespace VideoGameStore.Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<bool>
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public long RoleId { get; set; }
}