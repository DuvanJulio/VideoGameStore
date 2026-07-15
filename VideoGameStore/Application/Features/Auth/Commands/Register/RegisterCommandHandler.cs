using MediatR;
using VideoGameStore.Application.Features.Auth.Commands.Register.Validators;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var validator = new RegisterCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new DataValidationException(validationResult.Errors);
        }

        if (await _userRepository.ExistsByEmailAsync(request.Email))
        {
            throw new Exception("El correo ya está registrado.");
        }

        string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new UserEntity
        {
            Name = request.Name,
            Email = request.Email,
            Password = passwordHash,
            IdRole = request.RoleId
        };
        await _userRepository.AddAsync(user);

        return true;
    }
}