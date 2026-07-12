namespace VideoGameStore.Application.Interfaces;

public interface  ITokenService
{
    string GenerateToken(
        long idUser,
        string email,
        string role,
        DateTime expiration);
}