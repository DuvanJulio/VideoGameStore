using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Context
{
    public interface ICurrentUser
    {
        bool IsAuthenticated { get; }

        long? UserId { get; }

        string? Email { get; }

        string? Role { get; }

        Task<UserEntity?> GetUserAsync();
    }
}