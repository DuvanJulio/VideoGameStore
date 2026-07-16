namespace VideoGameStore.Domain.Contracts.Repository
{
    public interface IAuthorizableRequest
    {
        string RequiredRole { get; }
        long RequiredUserId { get; }
    }
}