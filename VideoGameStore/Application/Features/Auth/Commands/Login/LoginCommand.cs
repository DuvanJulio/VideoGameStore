using MediatR;
using VideoGameStore.Domain.DTOs;

namespace VideoGameStore.Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<AuthDTO>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}