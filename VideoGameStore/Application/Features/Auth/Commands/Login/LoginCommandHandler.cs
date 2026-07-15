using MediatR;
using VideoGameStore.Application.Interfaces;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.DTOs;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthDTO>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public LoginCommandHandler(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<AuthDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
    {

        var user = await _userRepository.GetByEmailAsync(request.Email.Trim().ToLower());

        if (user is null)
        {
            throw new UnauthorizedAccessException("Correo o contraseña incorrectos.");

        }

        bool isValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

        if (!isValid)
        {
            throw new UnauthorizedAccessException("Correo o contraseña incorrectos.");
        }

        string token = _tokenService.GenerateToken(
            idUser: user.Id,
            email: user.Email,
            role: user.IdRole.ToString(),
            expiration: DateTime.UtcNow.AddHours(2)
        );

        return new AuthDTO { Token = token };
    }
}