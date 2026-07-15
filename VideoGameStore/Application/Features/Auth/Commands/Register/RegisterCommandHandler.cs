using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;


namespace VideoGameStore.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {

        if (await _unitOfWork.UserRepository.ExistsByEmailAsync(request.Email))
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
        await _unitOfWork.UserRepository.AddAsync(user);
        await _unitOfWork.SaveChangeAsync(cancellationToken);

        return true;
    }
}